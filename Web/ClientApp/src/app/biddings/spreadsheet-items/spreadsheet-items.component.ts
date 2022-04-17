import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

import { SpreadsheetItemService } from './../../services/biddings/spreadsheet-item.service';

import { SpreadsheetItem } from 'src/app/models/bidding/spreadsheetitem.model';


@Component({
    selector: '[app-spreadsheet-item]',
    templateUrl: './spreadsheet-items.component.html',
    styleUrls: ['./spreadsheet-items.component.css']
})
export class SpreadsheetItemsComponent implements OnInit {
    @Input() item: SpreadsheetItem = new SpreadsheetItem();
    @Output() remove = new EventEmitter<number>();
    

    constructor(
        private spreadsheetItemService: SpreadsheetItemService
        
    ) { }

    ngOnInit(): void {
    }

    totalItemValue(): number{
        return this.item.amount * (this.item.manPower + this.item.material);
    }

    spreadsheetItemEdit(){
        this.spreadsheetItemService.updateSpreadsheetItem(this.item.spreadsheetItemId, this.item).subscribe(
            result => {
                console.log("Item editado com sucesso.");
            },
            err => {
                console.error("Ocorreu um erro ao tentarmos editar o item.");                
            }
        )
    }

    spreadsheetItemDelete(item: SpreadsheetItem){
        this.spreadsheetItemService.removeSpreadsheetItem(item.spreadsheetItemId).subscribe(
            result => {
                this.remove.emit(item.spreadsheetItemId);
                console.log("Item deletado com sucesso.");
            },
            err => {
                console.error("Ocorreu um erro ao deletar o item.");
            }
        )
    }
}

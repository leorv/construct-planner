import { SpreadsheetItemService } from './../../../services/biddings/spreadsheet-item.service';
import { LevelService } from './../../../services/biddings/level.service';
import { Level } from './../../../models/bidding/level.model';
import { Component, Input, OnInit } from '@angular/core';
import { SpreadsheetItem } from 'src/app/models/bidding/spreadsheetitem.model';

@Component({
    selector: 'app-level',
    templateUrl: './level.component.html',
    styleUrls: ['./level.component.css']
})
export class LevelComponent implements OnInit {
    @Input() level: Level = new Level();
    spreadsheetItems: SpreadsheetItem[] = [];
    item: SpreadsheetItem = new SpreadsheetItem();
    showSpreadsheetItem: boolean = true;

    constructor(
        private levelService: LevelService,
        private spreadsheetItemService: SpreadsheetItemService
    ) { }

    ngOnInit(): void {
        this.loadItems();
    }
    totalLevelValue(): number{
        var total:number = 0;
        for(let i = 0; i < this.spreadsheetItems.length; i++){
            var _itemTotal: number = this.spreadsheetItems[i].amount *
                (this.spreadsheetItems[i].manpower + this.spreadsheetItems[i].material);
            total = total + _itemTotal;
        }
        return total;
    }
    editLevel() {
        console.log(this.level.levelId.toString());
        console.log(this.level);        
        
        this.levelService.updateLevel(this.level.levelId, this.level).subscribe(
            result => {
                console.log("Sucesso ao editar o nível.");
            },
            err => {
                console.error("Ocorreu um erro ao tentar editar o nível.", err);

            }
        )
    }
    deleteLevel() {
        this.levelService.removeLevel(this.level.levelId).subscribe(
            result => {
                console.log("Nível deletado com sucesso.");
            },
            err => {
                console.error("Houve um erro ao tentar deletar o nível", err);
            }
        )
    }

    loadItems() {
        this.spreadsheetItemService.findSpreadsheetItems(this.level).subscribe(
            result => {
                this.spreadsheetItems = result;
                console.log("Sucesso ao buscar os itens do nível.");
            },
            err => {
                console.error("Ocorreu um erro ao buscar os itens do nível.", err);
            }
        )
    }

    addSpreadsheetItem(item: SpreadsheetItem) {
        item.levelId = this.level.levelId;
        this.spreadsheetItemService.createSpreadsheetItem(item).subscribe(
            result => {
                var _item = result;
                if (this.level.spreadsheetItems == null){
                    this.level.spreadsheetItems = [];
                }
                this.level.spreadsheetItems.push(_item);

                console.log("Item adicionado com sucesso.");
            },
            err => {
                console.error("Ocorreu um erro ao tentar adicionar o item.");
            }
        )
    }
}

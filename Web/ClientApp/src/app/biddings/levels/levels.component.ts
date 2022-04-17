import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges } from '@angular/core';

import { LevelService } from './../../services/biddings/level.service';
import { SpreadsheetItemService } from './../../services/biddings/spreadsheet-item.service';

import { Level } from './../../models/bidding/level.model';
import { SpreadsheetItem } from 'src/app/models/bidding/spreadsheetitem.model';

@Component({
    selector: 'app-level',
    templateUrl: './levels.component.html',
    styleUrls: ['./levels.component.css']
})
export class LevelsComponent implements OnInit {
    @Input() level: Level = new Level();
    spreadsheetItems: SpreadsheetItem[] = [];
    item: SpreadsheetItem = new SpreadsheetItem();
    @Output() remove = new EventEmitter<number>();

    constructor(
        private levelService: LevelService,
        private spreadsheetItemService: SpreadsheetItemService
    ) { }

    ngOnInit(): void {
        this.loadItems();
    }

    totalLevelValue(): number {
        var total: number = 0;
        for (let i = 0; i < this.spreadsheetItems.length; i++) {
            var _itemTotal: number = this.spreadsheetItems[i].amount *
                (this.spreadsheetItems[i].manPower + this.spreadsheetItems[i].material);
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
                this.remove.emit(this.level.levelId);
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
                console.log(this.spreadsheetItems);

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
                var _item: SpreadsheetItem = result;
                // if (this.level.spreadsheetItems == null){
                //     this.level.spreadsheetItems = [];
                // }
                this.spreadsheetItems.push(_item);

                console.log("Item adicionado com sucesso.");
            },
            err => {
                console.error("Ocorreu um erro ao tentar adicionar o item.");
            }
        )
    }

    removeItem(id: number) {
        var _index = this.spreadsheetItems.findIndex(s => s.spreadsheetItemId == id);
        this.spreadsheetItems.splice(_index, 1);
    }
}
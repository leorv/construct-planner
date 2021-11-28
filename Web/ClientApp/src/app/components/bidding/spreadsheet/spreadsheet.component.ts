import { Router } from '@angular/router';
import { LevelService } from './../../../services/biddings/level.service';
import { SpreadsheetItemService } from './../../../services/biddings/spreadsheet-item.service';
import { Component, OnInit } from '@angular/core';

import { Contract } from 'src/app/models/bidding/contract.model';
import { Spreadsheet } from 'src/app/models/bidding/spreadsheet.model';
import { Level } from './../../../models/bidding/level.model';
import { SpreadsheetItem } from './../../../models/bidding/spreadsheetitem.model';

import { DataTransferService } from './../../../services/data-transfer.service';
import { SpreadsheetService } from './../../../services/biddings/spreadsheet.service';

@Component({
    selector: 'app-spreadsheet',
    templateUrl: './spreadsheet.component.html',
    styleUrls: ['./spreadsheet.component.css']
})
export class SpreadsheetComponent implements OnInit {
    spreadsheets: Spreadsheet[] = [];
    selectedSpreadsheet: Spreadsheet = new Spreadsheet();
    levels: Level[] = [];
    selectedLevel: Level = new Level();
    selectedSpreadsheetItem: SpreadsheetItem = new SpreadsheetItem();
    contract: Contract = new Contract();

    constructor(
        private spreadsheetService: SpreadsheetService,
        private levelService: LevelService,
        private spreadsheetItemService: SpreadsheetItemService,
        private dataTransferService: DataTransferService,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.dataTransferService.objects.subscribe(
            result => {
                this.contract = result;
                this.getAllSpreadsheets();
            },
            err => {
                console.log("Ocorreu um erro ao verificar o contrato desta planilha.", err);
            }
        )
    }
    getAllSpreadsheets() {
        this.spreadsheetService.findSpreadsheets(this.contract).subscribe(
            result => {
                this.spreadsheets = result;
            },
            err => {
                console.log("Ocorreu um erro ao buscar as planilhas relativas a este contrato.", err);

            }
        )
    }

    getAllLevelsOfSpreadsheet() {
        this.levelService.findLevels(this.selectedSpreadsheet).subscribe(
            result => {
                this.levels = result;
                
                for (let level of this.levels) {
                    if (level.spreadsheetItems == null){
                        level.spreadsheetItems = [];
                    }
                    this.getSpreadsheetItemsOfLevel(level);
                }
            },
            err => {
                console.log("Ocorreu um erro ao buscar as planilhas relativas a este contrato.", err);

            }
        )
    }
    getSpreadsheetItemsOfLevel(level: Level) {
        this.spreadsheetItemService.findSpreadsheetItems(level).subscribe(
            result => {
                let _spreadsheetItems = result;
                if (_spreadsheetItems != null) {
                    var _levelIndex = this.levels.findIndex(l => l.levelId == _spreadsheetItems[0].levelId);
                    for (let item of _spreadsheetItems) {
                        this.levels[_levelIndex].spreadsheetItems.push(item);
                    }
                }
                else {
                    console.log("Nível: ".concat(level.name));
                    console.log("Não há nenhum item neste nível da planilha.");
                }
            },
            err => {
                console.log("Ocorreu um erro ao tentar buscar os itens de cada nível da planilha.");
            }
        )

    }
    selectSpreadsheet(id: number) {
        var _spreadsheet = this.spreadsheets.find(s => s.spreadsheetId == id);
        if (_spreadsheet != undefined) {
            this.selectedSpreadsheet = _spreadsheet;
            this.getAllLevelsOfSpreadsheet();
        }
        else {
            alert("Não existe nenhuma planilha cadastrada para este contrato.");
        }
    }
    newSpreadsheet() {
        let spreadsheet: Spreadsheet = new Spreadsheet();
        spreadsheet.additiveId = 1;
        spreadsheet.name = 'Planilha';
        spreadsheet.title = 'título';
        spreadsheet.description = 'descrição';
        spreadsheet.author = 'autor';
        spreadsheet.date = new Date();
        spreadsheet.contractId = this.contract.contractId;
        spreadsheet.additiveId = 1;

        this.spreadsheetService.createSpreadsheet(spreadsheet).subscribe(
            result => {
                let _spreadsheet: Spreadsheet = result;
                this.spreadsheets.push(_spreadsheet);
                console.log("Nova planilha criada com sucesso.");
                alert("Nova planilha criada com sucesso.");
            },
            err => {
                console.error("Ocorreu um erro ao criar uma nova planilha.", err);
            }
        )
    }
    shareData(spreadsheet: Spreadsheet) {
        this.dataTransferService.sendAnything(spreadsheet);
    }
    deleteSpreadsheet() {
        this.spreadsheetService.removeSpreadsheet(this.selectedSpreadsheet.spreadsheetId).subscribe(
            result => {
                var _index = this.spreadsheets.findIndex(s => s.spreadsheetId == this.selectedSpreadsheet.spreadsheetId);
                this.spreadsheets.splice(_index, 1);
                console.log("deletado com sucesso.");
            },
            err => {
                console.log("Ocorreu um erro ao deletar.", err);
            }
        )

    }
    totalLevelValue(level: Level): number {
        var total = 0;
        for (let item of level.spreadsheetItems) {
            total = total + (item.amount * (item.manpower + item.material));
        }
        return total;
    }
    totalItemValue(manpower: number, material: number, amount: number): number {
        var total = amount * (manpower + material);
        return total;
    }
    trackByFn(index: number, item: any) {
        return item.id;
    }
    SelectLevel(level: Level) {
        var _level = this.levels.find(l => l.levelId == level.levelId);
        if (_level != undefined) {
            this.selectedLevel = _level;
        }
        else {
            alert("Erro ao identificar o nível selecionado.");
        }
    }
    AddLevel() {
        console.clear();
        console.log("Criando novo nível.");

        let level: Level = new Level();
        level.name = 'Novo nível';
        level.title = 'Título';
        level.spreadsheetId = this.selectedSpreadsheet.spreadsheetId;
        console.log("Enviando para o serviço de criação.");

        this.levelService.createLevel(level).subscribe(
            result => {
                let _level: Level = result;
                this.levels.push(_level);
                console.log("Novo nível criado com sucesso.");
            },
            err => {
                console.error("Ocorreu um erro ao criar um novo nível.", err);
            }
        )
    }
    EditLevel() {
        this.levelService.updateLevel(this.selectedLevel.levelId, this.selectedLevel).subscribe(
            result => {
                console.log("Nível atualizado com sucesso.");
            },
            err => {
                console.error("Houve um erro ao tentar atualizar o nível.", err);
            }
        )
    }
    DeleteLevel() {
        this.levelService.removeLevel(this.selectedLevel.levelId).subscribe(
            result => {
                console.log("Nível deletado com sucesso.");
            },
            err => {
                console.error("Houve um erro ao tentar deletar o nível", err);
            }
        )
    }

    SelectSpreadsheetItem(item: SpreadsheetItem) {
        var _levelIndex = this.levels.findIndex(l => l.levelId == item.levelId);
        var _itemIndex = this.levels[_levelIndex].spreadsheetItems.findIndex(
            i => i.spreadsheetitemId == item.spreadsheetitemId);
        this.selectedSpreadsheetItem = this.levels[_levelIndex].spreadsheetItems[_itemIndex];
    }
    allSpreadsheetItemsOfLevel(level: Level): SpreadsheetItem[] {
        this.spreadsheetItemService.findSpreadsheetItems(level).subscribe(
            result => {
                let _levelIndex = this.levels.findIndex(l => l.levelId == level.levelId);
                this.levels[_levelIndex].spreadsheetItems = result;
                return this.levels[_levelIndex].spreadsheetItems;
            },
            err => {
                console.error("Ocorreu um erro ao carregar os itens da planilha.");                             
            }
        )
        return [];
        // let _levelIndex = this.levels.findIndex(l => l.levelId == level.levelId);
        // let spreadsheetItems: SpreadsheetItem[] = this.levels[_levelIndex].spreadsheetItems;
        // return spreadsheetItems;
    }
    addSpreadsheetItem() {
        let _spreadsheetItem: SpreadsheetItem = new SpreadsheetItem();
        _spreadsheetItem.description = 'novo item';
        _spreadsheetItem.amount = 0;
        _spreadsheetItem.code = 'código';
        _spreadsheetItem.levelId = this.selectedLevel.levelId;
        _spreadsheetItem.manpower = 0;
        _spreadsheetItem.material = 0;
        _spreadsheetItem.source = '';
        _spreadsheetItem.unit = '';

        this.spreadsheetItemService.createSpreadsheetItem(_spreadsheetItem).subscribe(
            result => {
                const _levelIndex = this.levels.findIndex(l => l.levelId == this.selectedLevel.levelId);
                var _spreadsheetItem = result;
                this.levels[_levelIndex].spreadsheetItems.push(_spreadsheetItem);
            },
            err =>{
                console.error("Ocorreu um erro ao tentar criar o item da planilha.", err);                
            }
        )
    }
    EditSpreadsheetItemSave() {
        this.spreadsheetItemService.updateSpreadsheetItem(
            this.selectedSpreadsheetItem.spreadsheetitemId, this.selectedSpreadsheetItem).subscribe(
                result => {
                    // let _spreadsheetItem: SpreadsheetItem = result;
                    // var _levelIndex = this.levels.findIndex(l => l.levelId == _spreadsheetItem.levelId);
                    console.log("Item criado com sucesso.");

                },
                err => {
                    console.error("Ocorreu um erro ao tentar editar o item.", err);
                    alert("Erro ao editar o item.");
                }
            )
    }
    spreadsheetItemDelete(item: SpreadsheetItem) {
        this.spreadsheetItemService.removeSpreadsheetItem(item.spreadsheetitemId).subscribe(
            result => {
                var _levelId = item.levelId;
                var _levelIndex = this.levels.findIndex(l => l.levelId == _levelId);
                var _itemIndex = this.levels[_levelIndex].spreadsheetItems.findIndex(
                    i => i.spreadsheetitemId == item.spreadsheetitemId);
                this.levels[_levelIndex].spreadsheetItems.splice(_itemIndex, 1);
                console.log("deletado com sucesso.");
                alert("Item deletado.");
            },
            err => {
                console.log("Ocorreu um erro ao deletar.", err);
            }
        )
    }

    


}
// public spreadsheetId: number,
//     public name: string,
//     public title: string,
//     public description: string,
//     public author: string,
//     public date: Date,
//     public encumberType: string,
//     public contractId: number,
//     public additiveId: number,
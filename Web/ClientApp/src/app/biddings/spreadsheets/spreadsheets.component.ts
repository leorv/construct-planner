import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

import { Contract } from 'src/app/models/bidding/contract.model';
import { Spreadsheet } from 'src/app/models/bidding/spreadsheet.model';
import { Level } from './../../models/bidding/level.model';
import { SpreadsheetItem } from './../../models/bidding/spreadsheetitem.model';

import { DataTransferService } from './../../services/data-transfer.service';
import { SpreadsheetService } from './../../services/biddings/spreadsheet.service';
import { LevelService } from './../../services/biddings/level.service';
import { SpreadsheetItemService } from './../../services/biddings/spreadsheet-item.service';

@Component({
    selector: 'app-spreadsheet',
    templateUrl: './spreadsheets.component.html',
    styleUrls: ['./spreadsheets.component.css']
})
export class SpreadsheetsComponent implements OnInit {
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
    selectSpreadsheet(id: number) {
        var _spreadsheet = this.spreadsheets.find(s => s.spreadsheetId == id);
        if (_spreadsheet != undefined) {
            this.selectedSpreadsheet = _spreadsheet;
            this.getAllLevelsOfSpreadsheet();
        }
        else {
            alert("N??o existe nenhuma planilha cadastrada para este contrato.");
        }
    }
    getAllLevelsOfSpreadsheet() {
        this.levelService.findLevels(this.selectedSpreadsheet).subscribe(
            result => {
                this.levels = result;
                this.levels.forEach(level => {
                    this.getItemsOfLevel(level);
                });
            },
            err => {
                console.log("Ocorreu um erro ao buscar as planilhas relativas a este contrato.", err);
            }
        )
    }
    getItemsOfLevel(level: Level) {
        for (let i = 0; i < this.levels.length; i++) {
            this.spreadsheetItemService.findSpreadsheetItems(level).subscribe(
                result => {
                    let _index = this.levels.findIndex(l => l.levelId == level.levelId);

                    this.levels[_index].spreadsheetItems = result;
                    console.log("itens do level ");
                    console.log(_index);
                },
                err => {
                    console.error("Ocorreu um erro ao buscar os itens do n??vel.", err);
                }
            )
        }

    }

    newSpreadsheet() {
        let spreadsheet: Spreadsheet = new Spreadsheet();
        spreadsheet.additiveId = 1;
        spreadsheet.name = 'Planilha';
        spreadsheet.title = 't??tulo';
        spreadsheet.description = 'descri????o';
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
    AddLevel() {
        console.clear();
        console.log("Criando novo n??vel.");

        let level: Level = new Level();
        level.name = 'Novo n??vel';
        level.title = 'T??tulo';
        level.spreadsheetId = this.selectedSpreadsheet.spreadsheetId;
        console.log("Enviando para o servi??o de cria????o.");

        this.levelService.createLevel(level).subscribe(
            result => {
                let _level: Level = result;
                this.levels.push(_level);
                console.log("Novo n??vel criado com sucesso.");
            },
            err => {
                console.error("Ocorreu um erro ao criar um novo n??vel.", err);
            }
        )
    }
    totalSpreadsheetValue(): number {
        let _total: number = 0;

        for (let i = 0; i < this.levels.length; i++) {
            if (this.levels[i].spreadsheetItems != null
                && this.levels[i].spreadsheetItems != []) {
                for (let j = 0; j < this.levels[i].spreadsheetItems.length; j++) {
                    _total = _total + this.levels[i].spreadsheetItems[j].amount
                        * (this.levels[i].spreadsheetItems[j].material
                            + this.levels[i].spreadsheetItems[j].manPower);
                }
            }
        }
        return _total;
    }
    removeLevel(id: number) {
        var _index = this.levels.findIndex(l => l.levelId == id);
        this.levels.splice(_index, 1);
    }
}
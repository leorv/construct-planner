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
                // Comentando essa parte para fazer a tentativa de passar dados pelo componente.
                // for (let level of this.levels) {
                //     if (level.spreadsheetItems == null){
                //         level.spreadsheetItems = [];
                //     }
                //     this.getSpreadsheetItemsOfLevel(level);
                // }
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
}
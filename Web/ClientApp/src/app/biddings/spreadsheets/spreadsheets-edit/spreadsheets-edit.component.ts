import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

import { Spreadsheet } from './../../../models/bidding/spreadsheet.model';

import { DataTransferService } from './../../../services/data-transfer.service';
import { SpreadsheetService } from './../../../services/biddings/spreadsheet.service';


@Component({
    selector: 'app-edit-spreadsheet',
    templateUrl: './spreadsheets-edit.component.html',
    styleUrls: ['./spreadsheets-edit.component.css']
})
export class SpreadsheetsEditComponent implements OnInit {
    spreadsheet: Spreadsheet = new Spreadsheet();

    constructor(
        private dataTransferService: DataTransferService,
        private spreadsheetService: SpreadsheetService,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.dataTransferService.objects.subscribe(
            result => {
                this.spreadsheet = result;
            },
            err => {
                console.error(err);
                alert("Erro ao carregar as informações da planilha.");
            }
        );
    }
    editSpreadsheet() {
        console.log("planilha enviada para requisição:");
        
        console.log(this.spreadsheet);
        
        this.spreadsheetService.updateSpreadsheet(this.spreadsheet.spreadsheetId, this.spreadsheet).subscribe(
            result => {
                console.log("Tudo certo. Planilha atualizada.", result);
            }
        );
        alert("Planilha atualizada.");
    }
    back() {
        this.router.navigate(['spreadsheets']);
    }
}

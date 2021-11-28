import { Router } from '@angular/router';
import { SpreadsheetService } from './../../../../../services/biddings/spreadsheet.service';
import { Spreadsheet } from './../../../../../models/bidding/spreadsheet.model';
import { DataTransferService } from './../../../../../services/data-transfer.service';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-edit-spreadsheet',
    templateUrl: './edit-spreadsheet.component.html',
    styleUrls: ['./edit-spreadsheet.component.css']
})
export class EditSpreadsheetComponent implements OnInit {
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
        // this.spreadsheet.contractId = 12;
        
        this.spreadsheetService.updateSpreadsheet(this.spreadsheet.spreadsheetId, this.spreadsheet).subscribe(
            result => {
                console.log("Tudo certo. Planilha atualizada.", result);
            },
            err => {
                console.error("Ocorreu um erro ao tentar atualizar a planilha.", err);
            }
        );
        alert("Planilha atualizada.");
    }
    back() {
        this.router.navigate(['spreadsheets']);
    }
}

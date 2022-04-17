import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BiddingsComponent } from './biddings.component';
import { AdditivesComponent } from './additives/additives.component';
import { ContractsComponent } from './contracts/contracts.component';
import { ClausesComponent } from './clauses/clauses.component';
import { LevelsComponent } from './levels/levels.component';
import { SpreadsheetsComponent } from './spreadsheets/spreadsheets.component';
import { SpreadsheetItemsComponent } from './spreadsheet-items/spreadsheet-items.component';
import { ContractsCreateComponent } from './contracts/contracts-create/contracts-create.component';
import { ContractsDetailsComponent } from './contracts/contracts-details/contracts-details.component';
import { ClausesCreateComponent } from './clauses/clauses-create/clauses-create.component';
import { ClausesEditComponent } from './clauses/clauses-edit/clauses-edit.component';
import { SpreadsheetsEditComponent } from './spreadsheets/spreadsheets-edit/spreadsheets-edit.component';

import { ContractService } from './../services/biddings/contract.service';
import { ClauseService } from '../services/biddings/clause.service';
import { SpreadsheetService } from '../services/biddings/spreadsheet.service';
import { SpreadsheetItemService } from '../services/biddings/spreadsheet-item.service';


@NgModule({
  declarations: [
    AdditivesComponent,
    BiddingsComponent,
    ClausesComponent,
    ClausesCreateComponent,
    ClausesEditComponent,
    ContractsComponent,
    ContractsCreateComponent,
    ContractsDetailsComponent,
    LevelsComponent,
    SpreadsheetsComponent,
    SpreadsheetsEditComponent,
    SpreadsheetItemsComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ],
  exports: [

  ],
  providers: [
    ContractService,
    ClauseService,
    SpreadsheetService,
    SpreadsheetItemService
  ]
})
export class BiddingsModule { }

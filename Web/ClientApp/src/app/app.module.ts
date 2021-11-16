import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouteGuard } from './authorization/route.guard';
import { LoginComponent } from './components/user/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { ContractComponent } from './components/bidding/contract/contract.component';
import { ContractDetailsComponent } from './components/bidding/contract/contract-details/contract-details.component';


import { UserService } from './services/user/user.service';
import { ContractService } from './services/biddings/contract.service';
import { ContractCreateComponent } from './components/bidding/contract/contract-create/contract-create.component';
import { AdditiveComponent } from './components/bidding/additive/additive.component';
import { ClauseComponent } from './components/bidding/clause/clause.component';
import { SpreadsheetComponent } from './components/bidding/spreadsheet/spreadsheet.component';
import { AdditiveagreementComponent } from './components/bidding/additiveagreement/additiveagreement.component';
import { ContractagreementComponent } from './components/bidding/contractagreement/contractagreement.component';
import { LevelComponent } from './components/bidding/level/level.component';
import { AddressComponent } from './components/common/address/address.component';
import { BdiComponent } from './components/price-reference/bdi/bdi.component';
import { InputComponent } from './components/price-reference/input/input.component';
import { SourceComponent } from './components/price-reference/source/source.component';
import { SourceItemComponent } from './components/price-reference/source-item/source-item.component';
import { SpreadsheetItemComponent } from './components/bidding/spreadsheet-item/spreadsheet-item.component';


@NgModule({
    declarations: [
        AppComponent,
        LoginComponent,
        HomeComponent,
        NavMenuComponent,
        ContractComponent,
        ContractDetailsComponent,
        ContractCreateComponent,
        AdditiveComponent,
        ClauseComponent,
        SpreadsheetComponent,
        AdditiveagreementComponent,
        ContractagreementComponent,
        LevelComponent,
        AddressComponent,
        BdiComponent,
        InputComponent,
        SourceComponent,
        SourceItemComponent,
        SpreadsheetItemComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        FormsModule
    ],
    providers: [
        ContractService,
        UserService,
        RouteGuard,
        { provide: 'BASE_URL', useFactory: getBaseUrl }
    ],
    bootstrap: [AppComponent]
})

export class AppModule {

}

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
import { ContractService } from './services/biddings/contract.service';
import { ContractDetailsComponent } from './components/bidding/contract/contract-details/contract-details.component';

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

import { UserService } from './services/user/user.service';


@NgModule({
    declarations: [
        AppComponent,
        LoginComponent,
        HomeComponent,
        NavMenuComponent,
        ContractComponent,
        ContractDetailsComponent
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
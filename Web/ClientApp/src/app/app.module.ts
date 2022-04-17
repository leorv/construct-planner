import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BiddingsModule } from './biddings/biddings.module';

import { RouteGuard } from './authorization/route.guard';

import { AppComponent } from './app.component';
import { CreateUserComponent } from './components/user/create-user/create-user.component';
import { LoginComponent } from './components/user/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';

import { UserService } from './services/user/user.service';
import { FileUploadService } from './components/admin/file-upload-service/file-upload.service';
import { DataTransferService } from './services/data-transfer.service';

import { LOCALE_ID } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import ptBr from '@angular/common/locales/pt';

registerLocaleData(ptBr)



@NgModule({
    declarations: [
        AppComponent,
        LoginComponent,
        HomeComponent,
        NavMenuComponent,
        CreateUserComponent     
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        FormsModule,
        BiddingsModule
    ],
    providers: [
        UserService,
        RouteGuard,
        FileUploadService,
        DataTransferService,
        { 
            provide: 'BASE_URL', 
            useFactory: getBaseUrl 
        },
        { 
            provide: LOCALE_ID,
            useValue: 'pt'
        }
    ],
    bootstrap: [AppComponent]
})

export class AppModule {

}

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
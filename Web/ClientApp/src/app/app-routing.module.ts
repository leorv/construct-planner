import { CreateUserComponent } from './components/user/create-user/create-user.component';
import { SpreadsheetComponent } from './components/bidding/spreadsheet/spreadsheet.component';
import { ClauseComponent } from './components/bidding/clause/clause.component';
import { ContractCreateComponent } from './components/bidding/contract/contract-create/contract-create.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { RouteGuard } from './authorization/route.guard';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/user/login/login.component';
import { ContractComponent } from './components/bidding/contract/contract.component';
import { ContractDetailsComponent } from './components/bidding/contract/contract-details/contract-details.component';

const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'login', component: LoginComponent },
    { path: 'create-user', component: CreateUserComponent },
    // TODO: Lembrar de colocar o canActivate nas rotas aqui...

    { path: 'contracts', component: ContractComponent, canActivate: [RouteGuard] },
    { path: 'contract-create', component: ContractCreateComponent, canActivate: [RouteGuard] },
    {
        path: 'contract-details/:id', component: ContractDetailsComponent, canActivate: [RouteGuard],
        children: [
            // { path: '', redirectTo:'clauses', pathMatch:'full'},
            { path: 'clauses', component: ClauseComponent },
            { path: 'spreadsheets', component: SpreadsheetComponent } // TODO: implementar medições.
        ]
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }

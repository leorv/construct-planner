import { SpreadsheetsEditComponent } from './biddings/spreadsheets/spreadsheets-edit/spreadsheets-edit.component';
import { CreateUserComponent } from './components/user/create-user/create-user.component';

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { RouteGuard } from './authorization/route.guard';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/user/login/login.component';
import { SpreadsheetsComponent } from './biddings/spreadsheets/spreadsheets.component';
import { ClausesComponent } from './biddings/clauses/clauses.component';
import { ContractsComponent } from './biddings/contracts/contracts.component';
import { ContractsCreateComponent } from './biddings/contracts/contracts-create/contracts-create.component';
import { ContractsDetailsComponent } from './biddings/contracts/contracts-details/contracts-details.component';

const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'login', component: LoginComponent },
    { path: 'create-user', component: CreateUserComponent },
    // TODO: Lembrar de colocar o canActivate nas rotas aqui...

    { path: 'contracts', component: ContractsComponent, canActivate: [RouteGuard] },
    { path: 'contract-create', component: ContractsCreateComponent, canActivate: [RouteGuard] },
    {
        path: 'contract-details/:id', component: ContractsDetailsComponent, canActivate: [RouteGuard],
        children: [
            // { path: '', redirectTo:'clauses', pathMatch:'full'},
            { path: 'clauses', component: ClausesComponent },
            { path: 'spreadsheets', component: SpreadsheetsComponent },
            { path: 'spreadsheets-edit', component: SpreadsheetsEditComponent }
            // TODO: implementar medições.
        ]
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }

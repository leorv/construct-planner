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
    // TODO: Lembrar de colocar o canActivate nas rotas aqui...

    { path: 'contracts', component: ContractComponent, canActivate: [RouteGuard] },
    { path: 'contract-create', component: ContractCreateComponent, canActivate: [RouteGuard] },
    { path: 'contract-details/:id', component: ContractDetailsComponent, canActivate: [RouteGuard] }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }

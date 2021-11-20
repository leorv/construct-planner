import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user/user.service';
import { User } from './../../../models/user.model';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-create-user',
    templateUrl: './create-user.component.html',
    styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {
    public returnUrl: string = '';
    public message: string = '';
    public spinnerActive: boolean = false;
    public user: User = new User();

    constructor(
        private userService: UserService,
        private router: Router
    ) { }

    ngOnInit(): void {
    }

    createUser() {
        this.userService.createUser(this.user).subscribe(
            user => {
                alert("Usuário cadastrado com sucesso.");
                this.router.navigate(['/login']);
            },
            err => {
                console.log('Ocorreu um erro ao cadastrar o contrato.', err);
                alert("Falha no cadastro de usuário.");
            }
        )
    }

}

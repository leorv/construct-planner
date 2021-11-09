import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";


import { User } from "src/app/models/user.model";
import { UserService } from "src/app/services/user/user.service";


@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
    public user: User;
    public returnUrl: string | undefined;
    public message: string | undefined;

    constructor(
        private router: Router,
        private activatedRoute: ActivatedRoute,
        private userService: UserService
    ) {
        this.user = new User(
            0, "", "", "", "", ""
        );
    }

    ngOnInit(): void {
        //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
        //Add 'implements OnInit' to the class.        
        this.returnUrl = this.activatedRoute.snapshot.queryParams['returnUrl'];

    }

    toEnter() {
        this.userService.UserVerify(this.user).subscribe(
            user_json => {
                // retorno sem erros;
                // var returnedUser: User;
                // returnedUser = data;
                // 
                // sessionStorage.setItem("UserEmail", returnedUser.email);
                // Somente para ver o que está retornando, depois excluir
                // ...
                // alert(this.returnUrl);

                this.userService.user = user_json;

                if (this.returnUrl == null) {
                    this.router.navigate(['/']);
                }
                else {
                    this.router.navigate([this.returnUrl]);
                }
            },
            err => {
                // console.log(err.error);
                this.message = err.error;
            }
        );
    }
}

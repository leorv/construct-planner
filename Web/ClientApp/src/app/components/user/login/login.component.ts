import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";


import { User } from "src/app/models/user.model";
import { UserService } from "src/app/services/user/user.service";


@Component({
    selector: 'app-login',
    templateUrl:'./login.component.html',
    styleUrls:['./login.component.css']
})

export class LoginComponent implements OnInit{
    public user: User;
    public returnUrl: string | undefined;
       
    constructor(
        private router: Router, 
        private activatedRoute: ActivatedRoute, 
        // public user: User, 
        private userService: UserService
        ) {
            this.user = new User(
                0,"","","","",""
            );
    }

    ngOnInit(): void {
        //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
        //Add 'implements OnInit' to the class.        
        this.returnUrl = this.activatedRoute.snapshot.queryParams['returnUrl'];
    }

    toEnter() {
        this.userService.UserVerify(this.user).subscribe(
            data => {

            },
            err => {

            }
        );
    }
}

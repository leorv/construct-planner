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

    public returnUrl: string = '';
    public message: string = '';
    public spinnerActive: boolean = false;
    public user: User = new User();

    constructor(
        private router: Router,
        private activatedRoute: ActivatedRoute,
        private userService: UserService,
    ) {        
    }

    ngOnInit(): void {
        this.returnUrl = this.activatedRoute.snapshot.queryParams['returnUrl'];
        this.spinnerActive = false;
    }

    toEnter() {
        this.spinnerActive = true;
        this.userService.UserVerify(this.user).subscribe(
            user_json => {
                this.userService.user = user_json;

                if (this.returnUrl == null) {
                    this.router.navigate(['/']);
                }
                else {
                    this.router.navigate([this.returnUrl]);
                }
            },
            err => {
                this.message = err.error;
            }
        );
        this.spinnerActive = false;
    }
}

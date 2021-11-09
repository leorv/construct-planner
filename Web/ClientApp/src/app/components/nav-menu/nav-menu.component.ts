import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user/user.service';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
    isExpanded = false;

    constructor(
        private router: Router,
        private userService: UserService
    ) {

    }

    collapse() {
        this.isExpanded = false;
    }

    toggle() {
        this.isExpanded = !this.isExpanded;
    }

    public loggedUser(): boolean {
        return this.userService.authenticatedUser();
    }

    logout(): void {
        // sessionStorage.setItem("AuthenticatedUser", "");
        this.userService.sessionClear();
        this.router.navigate(['/']);
    }

}

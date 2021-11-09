import { Injectable } from "@angular/core";
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from "@angular/router"
import { Observable } from "rxjs";
import { UserService } from "../services/user/user.service";

@Injectable({
    providedIn: 'root'
})
export class RouteGuard implements CanActivate {

    constructor(
        private router: Router,
        private userService: UserService
    ) {

    }

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    )
        : boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        if (this.userService.authenticatedUser()) {
            return true;
        }
        this.router.navigate(['/login'], {
            queryParams: { returnUrl: state.url }
        });
        return false;
    }

}

import { Injectable } from "@angular/core";
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree} from "@angular/router"
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class RouteGuard implements CanActivate{
    
    constructor(
        private router: Router
    ) {       
        
    }

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
        )
        : boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> 
        {
            var authenticated = sessionStorage.getItem("AuthenticatedUser");

            if (authenticated == "1"){
                return true;
            }
            this.router.navigate(['/login'], {
                queryParams: { returnUrl: state.url }
            });
            return false;
            // throw new Error("Method not implemented.");
    }

}

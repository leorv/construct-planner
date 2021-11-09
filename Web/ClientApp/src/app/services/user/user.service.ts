import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs"
import { User } from "src/app/models/user.model";

@Injectable({
    providedIn: "root"
})

export class UserService {
    private baseUrl: string;
    private _user!: User;

    get user(): User {
        let user_json = sessionStorage.getItem("AuthenticatedUser");
        if (user_json != null){
            this._user = JSON.parse(user_json);
            return this._user;
        }
        alert("Não foi possível obter informações do usuário.");
        return this._user;
    }    
    set user(user: User){
        sessionStorage.setItem("AuthenticatedUser", JSON.stringify(user));
        this._user = user;
    }

    public authenticatedUser(): boolean {
        return this._user != null 
            && this._user.email != "" 
            && this._user.password != "";
    }

    public sessionClear() {
        sessionStorage.setItem("AuthenticatedUser", "");
        this._user = new User(
            0,"","","","",""
        );
    }

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') baseUrl: string
    ) {
        this.baseUrl = baseUrl;
    }

    public UserVerify(user: User): Observable<User> {
        const headers = new HttpHeaders().set('content-type', 'application/json');

        var body = {
            email: user.email,
            password: user.password
        }

        var addressService = "api/user/UserVerify";
        return this.http.post<User>(this.baseUrl.concat(addressService), body, { headers });

    }
}


import { User } from './../../models/user.model';
import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs"

@Injectable({
    providedIn: "root"
})

export class UserService {
    private baseUrl: string;
    private _user!: User;
    private apiUrl: string = "api/user/";

    get user(): User {
        let user_json = localStorage.getItem("AuthenticatedUser");
        if (user_json != null) {
            this._user = JSON.parse(user_json);
            return this._user;
        }
        alert("Não foi possível obter informações do usuário.");
        return this._user;
    }
    set user(user: User) {
        localStorage.setItem("AuthenticatedUser", JSON.stringify(user));
        this._user = user;
    }

    public authenticatedUser(): boolean {
        return this._user != null
            && this._user.email != ""
            && this._user.password != "";
    }

    public sessionClear() {
        localStorage.setItem("AuthenticatedUser", "");
        this._user = new User();
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

        const address = "UserVerify";
        return this.http.post<User>(this.baseUrl.concat(this.apiUrl, address), body, { headers });
    }

    public getUserById(id: number): Observable<User> {
        var address = id.toString();
        return this.http.get<User>(this.baseUrl.concat(this.apiUrl,address));
    }

    public getAllUsers(): Observable<User[]> {
        return this.http.get<User[]>(this.baseUrl.concat(this.apiUrl));
    }

    // POST: Create
    public createUser(user: User): Observable<User> {
        return this.http.post<User>(this.baseUrl.concat(this.apiUrl), user);
    }

    // GET: All
    // public getUsers(): Observable<User[]> {
    //     return this.http.get<User[]>(this.baseUrl.concat(this.apiUrl));
    // }
}


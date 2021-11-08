import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs"
import { User } from "src/app/models/user.model";

@Injectable({
  providedIn: "root"
})

export class UserService {
  private baseUrl: string;

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


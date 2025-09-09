
import { Injectable, signal } from "@angular/core";
import { Router } from "@angular/router";

@Injectable({ providedIn: "root" })
export class AuthService {
  
  private _isAuthenticated = signal(false);

  isAuthenticated = this._isAuthenticated.asReadonly();


  constructor(private router: Router) {}


  public login(username: string, password: string): boolean {
    // For demo, accept any non-empty credentials
    if (username && password) {
      this._isAuthenticated.set(true);
      this.router.navigate(["/products"]);
      return true;
    }
    return false;
  }

  public logout(): void {
    this._isAuthenticated.set(false);
    this.router.navigate(["/login"]);
  }
  
}

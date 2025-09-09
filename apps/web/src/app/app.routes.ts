
//*  Angular
import { Routes } from "@angular/router";

//* Guards
import { authGuard } from "./core/guards/auth.guard";

//* Components
import { LoginComponent } from "./features/auth/login/login.component";
import { ProductDetailComponent } from "./features/products/product-detail/product-detail.component";
import { ProductListComponent } from "./features/products/product-list/product-list.component";

export const routes: Routes = [
  { path: "", redirectTo: "login", pathMatch: "full" },
  { path: "login", component: LoginComponent },
  { path: "products", component: ProductListComponent, canActivate: [authGuard] },
  { path: "products/:id", component: ProductDetailComponent, canActivate: [authGuard] },
  { path: "**", redirectTo: "products" }
];

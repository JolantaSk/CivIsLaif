import { HttpRequest, HttpInterceptor, HttpHandler } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from '../core/services/auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private auth: AuthService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    if (!this.auth.isAuthenticated) {
      return next.handle(req);
    }

    // Get the auth token from the service.
    const authToken = this.auth.token;

    // Clone the request and replace the original headers with
    // cloned headers, updated with the authorization.
    const authReq = req.clone({
      headers: req.headers.set('Authorization', 'Bearer ' + authToken)
    });

    // send cloned request with header to the next handler.
    return next.handle(authReq);
  }
}

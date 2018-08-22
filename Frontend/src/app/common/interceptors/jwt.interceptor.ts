import { Injectable } from '@angular/core';
import { HttpRequest, HttpResponse, HttpEvent, HttpHandler, HttpInterceptor } from '@angular/common/http';
import { tap } from 'rxjs/operators'
import { Observable } from 'rxjs';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor () {}

  intercept (request: HttpRequest<any>, next: HttpHandler) : Observable<HttpEvent<any>> {
    let token = localStorage.getItem('token');
    if (token) {
      request = request.clone({
        setHeaders: {
          'Authorization': `Bearer ${token}`
        }
      })
    }
    return next.handle(request)
      .pipe(tap((res: HttpEvent<any>) => {
        if (res instanceof HttpResponse && res.body.token) {
          this.saveToken(res.body);
        }
      }))
  }

  private saveToken (data) {
    localStorage.setItem('token', data.token);
    localStorage.setItem('admin', data.isAdmin);
    localStorage.setItem('username', data.name);
  }
}

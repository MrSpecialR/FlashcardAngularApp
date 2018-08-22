import { Injectable } from '@angular/core';
import { HttpRequest, HttpResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { tap, catchError } from 'rxjs/operators'
import { Observable, throwError } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

const ToastrConfig = {
  positionClass: 'toast-bottom-right',
  progressBar: true
}

@Injectable()
export class NotificationInterceptor implements HttpInterceptor {
  constructor (private toaster : ToastrService, router : Router) {

  }
  intercept (request: HttpRequest<any>, next: HttpHandler) : Observable<HttpEvent<any>> {
    return next.handle(request)
      .pipe (tap((res : HttpEvent<any>) => {
        if (res instanceof HttpResponse && res.body.message) {
          this.toaster.success(res.body.message, res.body.title ? res.body.title : "Success!", ToastrConfig);
        }
      }))
      .pipe(catchError((errorResponse: HttpErrorResponse) => {
        let status = errorResponse.status;
        let message = errorResponse.error.message;
        if (status === 401) {
          this.toaster.error(message, 'Unauthorized', ToastrConfig);
        } else if (status === 400) {
          this.toaster.error(message, 'Bad Request', ToastrConfig);
        }
        return throwError(errorResponse);
      }));
  }
}

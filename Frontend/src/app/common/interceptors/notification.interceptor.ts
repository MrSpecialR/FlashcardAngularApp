import { Injectable } from '@angular/core';
import { HttpRequest, HttpResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { tap, catchError, map } from 'rxjs/operators'
import { Observable, throwError } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';

const ToastrConfig = {
  positionClass: 'toast-bottom-right',
  progressBar: true
}

@Injectable()
export class NotificationInterceptor implements HttpInterceptor {
  isHandset : boolean;
  
  constructor (private toaster : ToastrService, private router : Router, private snackBar: MatSnackBar, private breakpointObserver: BreakpointObserver) {
    this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    ).subscribe(isHandset => {
      this.isHandset = isHandset;
    });
  }
  intercept (request: HttpRequest<any>, next: HttpHandler) : Observable<HttpEvent<any>> {
    return next.handle(request)
      .pipe (tap((res : HttpEvent<any>) => {
        if (res instanceof HttpResponse && res.body.message) {
            if(this.isHandset) {
              this.snackBar.open(res.body.message, 'Close', {
                duration: 2500
              });
            } else {
              this.toaster.success(res.body.message, res.body.title ? res.body.title : "Success!", ToastrConfig);
            }
        }
      }))
      .pipe(catchError((errorResponse: HttpErrorResponse) => {
        let status = errorResponse.status;
        let message = '';
        if (errorResponse.error) {
          message = errorResponse.error.message;
        }
        if (status === 0) {
          message = 'Server is down. Please try again later!';
        }
        if(this.isHandset) {
          let snackBarConfig : MatSnackBarConfig = {
            duration: 5000
          };

          if (status === 0) {
            delete snackBarConfig.duration;
          }

          debugger
          if (status == 404 && errorResponse.url.includes('AccessDenied')) {
            status = 401;
            message = "You are unauthorized to do this";
          }

          this.snackBar.open(message, 'Close', );
          if (status === 401) {
            this.router.navigate(['/login']);
          }
        } else {  
          if (status === 0) {
            this.toaster.warning(message, 'Server Error', {
              disableTimeOut: true,
              positionClass: ToastrConfig.positionClass
            });
          }
          if (status === 401) {
            this.toaster.error(message, 'Unauthorized', ToastrConfig);
            this.router.navigate(['/login']);
          } else if (status === 400) {
            this.toaster.error(message, 'Bad Request', ToastrConfig);
          }
      }
        return throwError(errorResponse);
      }));
  }
}

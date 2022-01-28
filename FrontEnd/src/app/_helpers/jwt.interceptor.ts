import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root',
  })
export class JwtInterceptor implements HttpInterceptor {
    constructor() {}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // add authorization header with jwt token if available
        let usuarioAutenticado = JSON.parse(localStorage.getItem('usuarioAutenticado'))
        
        if (usuarioAutenticado && usuarioAutenticado.acessToken) {
            request = request.clone({
                setHeaders: { 
                    Authorization: `Bearer ${usuarioAutenticado.acessToken}`
                }
            });
        }

        return next.handle(request);
    }
}
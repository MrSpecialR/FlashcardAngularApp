import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { LoginModel } from "./models/LoginModel";
import { RegisterModel } from './models/RegisterModel';

import { BASE_URL } from '../common/constants';

const USERS_BASE_URL : string = BASE_URL + '/users/';



@Injectable()
export class AuthenticationService {
  constructor (private http: HttpClient) {
   }

  login (data : LoginModel) {
    debugger
    return this.http.post(USERS_BASE_URL + 'login', data);
  }

  register (data : RegisterModel) {
    return this.http.post(USERS_BASE_URL + 'register', data);
  }

  logout () {
    localStorage.removeItem('token');
    localStorage.removeItem('username');
    localStorage.removeItem('admin');

  }

  get isAdmin () {
    return localStorage.getItem('admin') === 'true';
  }
  
  get username () {
    return localStorage.getItem('username');
  }

  get isLogged () {
    let token = localStorage.getItem('token');
    return token != null;
  }
}

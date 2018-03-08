import { Inject, Injectable } from '@angular/core';
import { Todo } from './todo';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class TodoService {
	private http: Http;
	private baseUrl: string;

	constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
		this.http = http;
		this.baseUrl = baseUrl;
	}

	addTodo(todo: Todo): Observable<Todo> {
		return this.http.post(this.baseUrl + 'api/todo', todo).map(result => todo);
	}

	deleteTodo(todo: Todo): Observable<Todo> {
		return  this.http.delete(this.baseUrl + 'api/todo/' + todo.id).map(result => todo);
	}

	updateTodo(todo: Todo): Observable<Todo> {
		return this.http.put(this.baseUrl + 'api/todo/' + todo.id, todo).map(result => todo);
	}

	getAll(): Observable<Todo[]> {
		return this.http.get(this.baseUrl + 'api/todo')
			.map(result => result.json() as Todo[]);
	}
}
import { Component } from '@angular/core';
import { Todo } from './todo';
import { TodoService } from './todo.service';
import { Observable } from 'rxjs/Observable';

@Component({
	selector: 'todo',
	templateUrl: './todo.component.html',
	styleUrls: ['../../../../node_modules/todomvc-app-css/index.css', '../../../../node_modules/todomvc-common/base.css'],
	providers: [TodoService]
})
export class TodoComponent {
	private isLoading: boolean = false;
	private items: Todo[] = [];

	newTodo: Todo = new Todo();

	constructor(private todoService: TodoService) {
	}

	ngOnInit() {
		this.todoService.getAll().subscribe(todos => this.items = todos);
	}

	addTodo() {
		this.todoService.addTodo(this.newTodo).subscribe(todo => this.items.push(todo));
		this.newTodo = new Todo();
	}

	toggleTodoComplete(todo: Todo) {
		todo.complete = !todo.complete;
		this.todoService.updateTodo(todo).subscribe();
	}

	removeTodo(todo: Todo) {
		this.todoService.deleteTodo(todo).subscribe(todo => this.items = this.items
			.filter(item => item.id != todo.id));
	}

	get todos() {
		return this.items;
	}

}
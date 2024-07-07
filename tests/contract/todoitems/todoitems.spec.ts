import { createApiClient } from '../utils/Agent'
import { TodoApi, TodoApiInterface, TodoItem } from "../generated/";
import { AxiosResponse } from "axios";
import { config } from "../config/base";
import { loadApiSpec } from "../utils/Specs";
import { v4 as uuidv4 } from 'uuid'

describe("Given the backend endpoint",  () => {
    let todoApiInterface: TodoApiInterface;
    beforeEach(async () => {
        todoApiInterface = new TodoApi(undefined, config.backendBaseUrl, createApiClient());
    });

    describe("When getting todo items",  () => {
        
        test("Then the client should receive a status code of 200 and the response data should match the TodoItems schema.", async() => {
            let todoItemsResponse: AxiosResponse<TodoItem[]>;
            
            todoItemsResponse = await todoApiInterface.getTodoItems();

            expect(todoItemsResponse.status).toBe(200);

            let todoItemsResults: TodoItem[] = todoItemsResponse.data;

            loadApiSpec("webapi.openapi.yaml");
            expect(todoItemsResults).toSatisfySchemaInApiSpec("TodoItems");
        });
    });

    describe("When getting a todo item",  () => {

        test("Then the client should receive a status code of 404 when an {id} does not exist.", async () => {
            let todoItemResponse: AxiosResponse<TodoItem>;
            let todoItemId: string;

            todoItemId = "ee485473-aeb7-4960-a784-8bf97705e7b9"
            todoItemResponse = await todoApiInterface.getTodoItem(todoItemId);

            expect(todoItemResponse.status).toBe(404);
        });
    });

    describe("When creating a todo item", () => {
        let todoItemId: string | undefined;
        let todoItem: TodoItem = {
            id: uuidv4()  ,
            description: "contract test created todo item.",
            isCompleted: false
        }

        //TODO: Missing validation for empty GUIDs
        
        test("Then the client should receive a status code of 400 when the description is empty.", async() => {

            let todoItemDescriptionResponse: AxiosResponse<TodoItem>;

            todoItemDescriptionResponse = await todoApiInterface.postTodoItem({
                id: uuidv4()  ,
                description: "",
                isCompleted: false
            });

            expect(todoItemDescriptionResponse.status).toBe(400);
        });
        
        test("Then the client should receive a status code of 201 when the body is valid JSON.", async() => {

            let todoItemCreateResponse: AxiosResponse<TodoItem>;

            todoItemCreateResponse = await todoApiInterface.postTodoItem(todoItem);
           
            expect(todoItemCreateResponse.status).toBe(201);

            let todoItemCreateResult: TodoItem = todoItemCreateResponse.data;

            todoItemId = todoItemCreateResult.id;
            
            loadApiSpec("webapi.openapi.yaml");
            expect(todoItemCreateResult).toSatisfySchemaInApiSpec("TodoItem");
        });

        test("Then the client should receive a status code of 200 when retrieving the created todo item.", async() => {

            let todoItemRetrieveResponse: AxiosResponse<TodoItem>;
            
            todoItemRetrieveResponse = await todoApiInterface.getTodoItem(todoItemId ?? 'default-id');

            expect(todoItemRetrieveResponse.status).toBe(200);

            let todoItemRetrieveResult: TodoItem = todoItemRetrieveResponse.data;

            loadApiSpec("webapi.openapi.yaml");
            expect(todoItemRetrieveResult).toSatisfySchemaInApiSpec("TodoItem");
        });

        test("Then the client should receive a status code of 400 when creating a todo item with a duplicate description.", async() => {

            let todoItemDuplicateResponse: AxiosResponse<TodoItem>;

            todoItemDuplicateResponse = await todoApiInterface.postTodoItem(todoItem);

            expect(todoItemDuplicateResponse.status).toBe(400);
        });
    });

    describe("When updating a todo item",  () => {
        let todoItemId: string | undefined;
        let todoItem: TodoItem = {
            id: uuidv4()  ,
            description: "contract test updated todo item.",
            isCompleted: false
        }
        
        //TODO: Missing validation for empty GUIDs

        test("Then the client should receive a status code of 201 when the body is valid JSON.", async () => {
            let todoItemCreateResponse: AxiosResponse<TodoItem>;
            todoItemCreateResponse = await todoApiInterface.postTodoItem(todoItem);

            expect(todoItemCreateResponse.status).toBe(201);

            let todoItemCreateResult: TodoItem = todoItemCreateResponse.data;
            todoItemId = todoItemCreateResult.id;

            loadApiSpec("webapi.openapi.yaml");
            expect(todoItemCreateResult).toSatisfySchemaInApiSpec("TodoItem");
        });

        test("Then the client should receive a 400 when the {id} in the path does not match the todo item id.", async () => {
            let todoItemUpdateResponse: AxiosResponse<void>;
            todoItemUpdateResponse = await todoApiInterface.putTodoItem(uuidv4(), todoItem);

            expect(todoItemUpdateResponse.status).toBe(400);
        });

        test("Then the client should receive a 204 when the {id} in the path matches the todo item id.", async () => {
            let todoItemUpdateResponse: AxiosResponse<void>;
            todoItemUpdateResponse = await todoApiInterface.putTodoItem(todoItem.id ?? 'default-id', todoItem);

            expect(todoItemUpdateResponse.status).toBe(204);
        });
    });
});
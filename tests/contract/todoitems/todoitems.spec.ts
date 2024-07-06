import { createApiClient } from '../utils/Agent'
import {
    TodoApi,
    TodoApiInterface, TodoItem
} from "../generated/";
import {AxiosResponse} from "axios";
import {config} from "../config/base";
import { loadApiSpec } from "../utils/Specs";

describe("Given the backend endpoint", () => {
    let todoApiInterface: TodoApiInterface;
    let todoItemsResponse: AxiosResponse<TodoItem[]>;
    beforeEach(async () => {
        todoApiInterface = new TodoApi(undefined, config.backendBaseUrl, createApiClient());
        todoItemsResponse = await todoApiInterface.getTodoItems();
    });

    describe("When getting todo items", () => {
        test("Then the service should give back a status of 200 and the response data should match the TodoItems schema", () => {
            expect(todoItemsResponse.status).toBe(200);

            let result: TodoItem[] = todoItemsResponse.data;

            loadApiSpec("webapi.openapi.yaml");
            expect(result).toSatisfySchemaInApiSpec("TodoItems");
        });
    });
});
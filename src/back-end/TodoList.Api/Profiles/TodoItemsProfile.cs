using AutoMapper;

namespace TodoList.Api.Profiles
{
    public class TodoItemsProfile : Profile
    {
        public TodoItemsProfile()
        {
            CreateMap<TodoItem, Generated.TodoItem>();
        }
    }
}

using AutoMapper;
using mvc.Models;

public class DomainProfile : Profile
{
	public DomainProfile()
	{
		CreateMap<TodoItem, TodoViewModel>();
		CreateMap<TodoViewModel, TodoItem>();
	}
}
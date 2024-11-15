using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace SnackHub.Payment.Application.Services;

internal abstract class BaseService
{
    public ILogger Logger { get; set; }
    public IMapper Mapper { get; set; }
    public BaseService(ILogger logger, IMapper mapper)
    {
        Logger = logger;
        Mapper = mapper;
    }
}
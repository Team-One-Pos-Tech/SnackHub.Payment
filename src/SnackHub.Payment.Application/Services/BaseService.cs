using AutoMapper;
using Microsoft.Extensions.Logging;
using SnackHub.Payment.Application.Interfaces;
using SnackHub.Payment.Domain.Entities;
using SnackHub.Payment.Domain.Interface;
using SnackHub.Payment.Infra.interfaces;

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
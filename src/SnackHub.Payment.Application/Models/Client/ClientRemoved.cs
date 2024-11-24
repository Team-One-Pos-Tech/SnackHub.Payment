using System;
using MassTransit;

namespace SnackHub.Payment.Application.Models.Client;

[MessageUrn("snack-hub-clients")]
[EntityName("client-removed")]
public record ClientRemoved(Guid Identifier);
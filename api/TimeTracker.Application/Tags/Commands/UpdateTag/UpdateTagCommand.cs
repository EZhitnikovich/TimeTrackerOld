﻿using MediatR;

namespace TimeTracker.Application.Tags.Commands.UpdateTag
{
    public class UpdateTagCommand: IRequest
    { // TODO: add user id
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
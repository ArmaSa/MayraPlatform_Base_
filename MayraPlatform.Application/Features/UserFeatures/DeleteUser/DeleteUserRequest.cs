using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayraPlatform.Application.Features.UserFeatures.DeleteUser
{
    public class DeleteUserRequest:IRequest<DeleteUserResponse>
    {
        [Required]
        public string? Email { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalLearning.Services.ResponseModel
{
    public static class AccountResponse
    {
        //DTO: data transfer object: che phur đi những thứ k cần thiết, chỉ lấy thứ cần thiết
        public record GetAccountsModel(
        
            int Id,
            string FullName,
            string Email,
            string PasswordHash,
            string Role,
            DateTimeOffset CreatedAt,
            DateTimeOffset UpdatedAt
        );


    }
}

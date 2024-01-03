using Microsoft.Data.SqlClient;

namespace Blog.Screens.RoleScreen;

public class DeleteRoleScreen
{

    public static void Load(SqlConnection connection)
    {
        var art = @"
              _____   ______  _       ______  _______  ______      _____    ____   _       ______  
             |  __ \ |  ____|| |     |  ____||__   __||  ____|    |  __ \  / __ \ | |     |  ____| 
             | |  | || |__   | |     | |__      | |   | |__       | |__) || |  | || |     | |__    
             | |  | ||  __|  | |     |  __|     | |   |  __|      |  _  / | |  | || |     |  __|   
             | |__| || |____ | |____ | |____    | |   | |____     | | \ \ | |__| || |____ | |____  
             |_____/ |______||______||______|   |_|   |______|    |_|  \_\ \____/ |______||______|                                                                        
        ";
        
        //TODO: CRIAR TRIGGER NO DB PARA DELETAR RELAÇÃO USER - ROLE
        
    }

   
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TF.Business.WMS
{
    /*
    CREATE TABLE [dbo].[BUSINESS.WMS.PRODUCT_N_SERVICE_CATEGORY](
	    [GUID_RECORD] [uniqueidentifier] NOT NULL,
	    [CATEGORY_GUID] [uniqueidentifier] NOT NULL,
	    [ITEM_GUID] [uniqueidentifier] NOT NULL,
	    [BATCH_GUID] [uniqueidentifier],
	    [HIDDEN] [bit] NOT NULL,
	    [DELETED] [bit] NOT NULL
    ) ON [PRIMARY]
    */

    public class ProductCategory
    {
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }
        public Guid ProductId { get; set; }
    }
}

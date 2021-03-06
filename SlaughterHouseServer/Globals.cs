﻿namespace SlaughterHouseServer
{
    public static class ConstErrorMsg
    {
        public const string ProductNull = "กรุณาระบุสินค้า";
        public const string DayIsZero = "จำนวนวันต้องมากกกว่า 0";
        public const string UnitPriceIsZero = "ราคาต้องมากกกว่า 0";

    }
    public static class ConstColumns
    {
        //'ZZZZZZZZZZZZZZZZZZZ
        public const string BTN_INVOICE = "BTN_INVOICE";
        public const string BTN_PRODUCT_SLIP = "BTN_PRODUCT_SLIP";

        public const string REQUEST_DATE = "REQUEST_DATE";
        public const string QTY_WGH = "QTY_WGH";
        public const string QTY_WGH_LOCATION = "QTY_WGH_LOCATION";
        public const string SELECT_COL = "SELECT_COL";


        public const string ACTIVE = "ACTIVE";
        public const string ADDRESS = "ADDRESS";
        public const string BARCODE_NO = "BARCODE_NO";
        public const string BOM_CODE = "BOM_CODE";
        public const string BREEDER_CODE = "BREEDER_CODE";
        public const string BREEDER_NAME = "BREEDER_NAME";


        public const string CHILL_QTY = "CHILL_QTY";
        public const string CHILL_WGH = "CHILL_WGH";
        public const string COMMENTS = "COMMENTS";
        public const string CONTACT_NO = "CONTACT_NO";
        public const string COOP_NO = "COOP_NO";
        public const string CREATE_AT = "CREATE_AT";
        public const string CREATE_BY = "CREATE_BY";
        public const string CUSTOMER_CODE = "CUSTOMER_CODE";
        public const string CUSTOMER_NAME = "CUSTOMER_NAME";
        public const string DAY = "DAY";
        public const string DRIVER = "DRIVER";


        public const string DESCRIPTION = "DESCRIPTION";
        public const string DISC_AMT = "DISC_AMT";
        public const string DISC_AMT_BILL = "DISC_AMT_BILL";
        public const string DISCOUNT_PER = "DISCOUNT_PER";
        public const string DOCUMENT_TYPE = "DOCUMENT_TYPE";
        public const string DOC_NO = "DOC_NO";
        public const string CLASS_ID = "CLASS_ID";
        public const string CLASS_NAME = "CLASS_NAME";
        public const string END_DATE = "END_DATE";
        public const string EST_NO = "EST_NO";
        public const string FACTORY_QTY = "FACTORY_QTY";
        public const string FACTORY_WGH = "FACTORY_WGH";
        public const string FARM_CODE = "FARM_CODE";
        public const string FARM_NAME = "FARM_NAME";
        public const string FARM_QTY = "FARM_QTY";
        public const string FARM_WGH = "FARM_WGH";
        public const string GROSS_AMT = "GROSS_AMT";
        public const string INVOICE_DATE = "INVOICE_DATE";
        public const string INVOICE_FLAG = "INVOICE_FLAG";
        public const string INVOICE_NO = "INVOICE_NO";
        public const string ISSUE_UNIT_METHOD = "ISSUE_UNIT_METHOD";
        public const string LOCATION_CODE = "LOCATION_CODE";
        public const string LOCATION_NAME = "LOCATION_NAME";
        public const string LOT_NO = "LOT_NO";
        public const string MAX_WEIGHT = "MAX_WEIGHT";
        public const string MIN_WEIGHT = "MIN_WEIGHT";
        public const string MODIFIED_AT = "MODIFIED_AT";
        public const string MODIFIED_BY = "MODIFIED_BY";
        public const string MUTIPLY_QTY = "MUTIPLY_QTY";
        public const string MUTIPLY_WGH = "MUTIPLY_WGH";
        public const string NET_AMT = "NET_AMT";
        public const string ORDER_DATE = "ORDER_DATE";
        public const string ORDER_FLAG = "ORDER_FLAG";
        public const string ORDER_NO = "ORDER_NO";
        public const string ORDER_QTY = "ORDER_QTY";
        public const string ORDER_SET_QTY = "ORDER_SET_QTY";
        public const string ORDER_SET_WGH = "ORDER_SET_WGH";
        public const string ORDER_WGH = "ORDER_WGH";
        public const string PACKING_SIZE = "PACKING_SIZE";
        public const string PLANT_ID = "PLANT_ID";
        public const string PLANT_NAME = "PLANT_NAME";
        public const string PO_DATE = "PO_DATE";
        public const string PO_FLAG = "PO_FLAG";
        public const string PO_NO = "PO_NO";
        public const string PO_QTY = "PO_QTY";
        public const string PO_WGH = "PO_WGH";
        public const string PRODUCTION_DATE = "PRODUCTION_DATE";
        public const string PRODUCT_CODE = "PRODUCT_CODE";
        public const string PRODUCT_GROUP_CODE = "PRODUCT_GROUP_CODE";
        public const string PRODUCT_GROUP_NAME = "PRODUCT_GROUP_NAME";
        public const string PRODUCT_NAME = "PRODUCT_NAME";
        public const string PRINT_NO = "PRINT_NO";
        public const string QTY = "QTY";
        public const string QUEUE_NO = "QUEUE_NO";
        public const string RECEIPT_NO = "RECEIPT_NO";
        public const string RECEIVE_DATE = "RECEIVE_DATE";
        public const string RECEIVE_FLAG = "RECEIVE_FLAG";
        public const string RECEIVE_NO = "RECEIVE_NO";
        public const string RECEIVE_QTY = "RECEIVE_QTY";
        public const string RECEIVE_WGH = "RECEIVE_WGH";
        public const string REF_DOCUMENT_NO = "REF_DOCUMENT_NO";
        public const string REF_DOCUMENT_TYPE = "REF_DOCUMENT_TYPE";
        public const string RUNNING = "RUNNING";
        public const string SALE_UNIT_METHOD = "SALE_UNIT_METHOD";
        public const string SEQ = "SEQ";
        public const string SEX_FLAG = "SEX_FLAG";
        public const string SHELFLIFE = "SHELFLIFE";
        public const string SHIP_TO = "SHIP_TO";
        public const string START_DATE = "START_DATE";
        public const string STD_YIELD = "STD_YIELD";
        public const string STOCK_DATE = "STOCK_DATE";
        public const string STOCK_ITEM = "STOCK_ITEM";
        public const string STOCK_NO = "STOCK_NO";
        public const string STOCK_QTY = "STOCK_QTY";
        public const string STOCK_WGH = "STOCK_WGH";
        public const string TAX_ID = "TAX_ID";
        public const string TRANSACTION_TYPE = "TRANSACTION_TYPE";
        public const string TRANSPORT_DATE = "TRANSPORT_DATE";
        public const string TRANSPORT_DOC_NO = "TRANSPORT_DOC_NO";
        public const string TRANSPORT_FLAG = "TRANSPORT_FLAG";
        public const string TRANSPORT_NO = "TRANSPORT_NO";
        public const string TRANSPORT_QTY = "TRANSPORT_QTY";
        public const string TRANSPORT_WGH = "TRANSPORT_WGH";
        public const string TRUCK_ID = "TRUCK_ID";
        public const string TRUCK_NO = "TRUCK_NO";
        public const string TRUCK_TYPE_ID = "TRUCK_TYPE_ID";
        public const string TRUCK_TYPE_DESC = "TRUCK_TYPE_DESC";
        public const string UNIT_CODE = "UNIT_CODE";
        public const string UNIT_NAME = "UNIT_NAME";
        public const string UNIT_CODE_QTY = "UNIT_CODE_QTY";
        public const string UNIT_NAME_QTY = "UNIT_NAME_QTY";
        public const string UNIT_CODE_WGH = "UNIT_CODE_WGH";
        public const string UNIT_NAME_WGH = "UNIT_NAME_WGH";
        public const string UNIT_OF_QTY = "UNIT_OF_QTY";
        public const string UNIT_OF_WGH = "UNIT_OF_WGH";
        public const string UNIT_PRICE = "UNIT_PRICE";
        public const string UNIT_DISC = "UNIT_DISC";
        public const string DISC_PER = "DISC_PER";
        public const string UNLOAD_QTY = "UNLOAD_QTY";
        public const string UNLOAD_WGH = "UNLOAD_WGH";
        public const string VAT_AMT = "VAT_AMT";
        public const string VAT_RATE = "VAT_RATE";
        public const string WGH = "WGH";

        public const string UNIT_PRICE_CURRENT = "UNIT_PRICE_CURRENT";


        public const string Active = "Active";
        public const string Address = "Address";
        public const string BomCode = "BomCode";
        public const string ClassId = "ClassId";
        public const string ClassName = "ClassName";
        public const string ContactNo = "ContactNo";
        public const string CreateAt = "CreateAt";
        public const string CreateBy = "CreateBy";
        public const string CustomerCode = "CustomerCode";
        public const string CustomerName = "CustomerName";
        public const string Day = "Day";
        public const string DefaultFlag = "DefaultFlag";
        public const string DiscountPer = "DiscountPer";
        public const string EndDate = "EndDate";
        public const string ModifiedAt = "ModifiedAt";
        public const string ModifiedBy = "ModifiedBy";
        public const string ProductCode = "ProductCode";
        public const string ProductName = "ProductName";
        public const string ShipTo = "ShipTo";
        public const string StartDate = "StartDate";
        public const string TaxId = "TaxId";
        public const string UnitPrice = "UnitPrice";
        public const string TruckTypeId = "TruckTypeId";
        public const string TruckTypeDesc = "TruckTypeDesc";


        public const string PlantId = "PlantId";
        public const string ProductionDate = "ProductionDate";
        public const string PlantName = "PlantName";
        public const string EstNo = "EstNo";
        public const string LogoImage = "LogoImage";
    }


}

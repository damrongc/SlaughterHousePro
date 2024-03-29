﻿using System.Configuration;
using System.Windows.Forms;
public static class Constants
{
    public static string INV = "INV";
    public static string ISS = "ISS";
    public static string REV = "REV";
    public static string PO = "PO";
    public static string SO = "SO";
    public static string STK = "STK";
    public static string TP = "TP";
    public static string DEL = "DEL";
    public static string BAR = "BAR";
    //public static string CREATE_BY = "auto";
    public static string CHOOSE_QUEUE = "กรุณาเลือกข้อมูล";
    public static string CHOOSE_WH = "กรุณาเลือกคลังสินค้า";
    public static string CHOOSE_TRUCK = "กรุณาเลือกทะเบียนรถ";
    public static string START_WAITING = "กรุณาเริ่มชั่ง";
    public static string PRODUCT_WAITING = "กรุณาเลือกสินค้า";
    public static string WEIGHT_WAITING = "กรุณาชั่งน้ำหนัก";
    public static string MINWEIGHT_WAITING = "กรุณายกสินค้าออก";
    public static string PLEASE_SCAN = "กรุณาสแกนสินค้า";
    public static string SAVE_SUCCESS = "บันทึกน้ำหนัก เรียบร้อยแล้ว.";
    public static string PROCESSING = "กำลังบันทึกข้อมูล...";
    public static decimal MIN_WEIGHT_RESET = 0.5m;
    public static string SCALEPORT = ConfigurationManager.AppSettings["ScalePort"].ToString();
    public static string TWPORT = ConfigurationManager.AppSettings["TowerlightPort"].ToString();
    public static string STABLE_TARGET = ConfigurationManager.AppSettings["StableTarget"].ToString();
    public static string FONT_FAMILY = "Kanit";
    public static float FONT_SIZE = 12;
    public static string REPORT_FILE = Application.StartupPath + "\\Report\\Rpt\\barcode_and_qrcode.rpt";
}


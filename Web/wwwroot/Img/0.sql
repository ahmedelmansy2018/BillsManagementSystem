
 --Sp_BillPrint 16
 alter proc Sp_BillPrint 
@Id int 
as 
select 
header.BILCOD as BillingHeaderNumber,
header.BILDAT as BillingHeaderDate,	
header.BILPRC as BillingHeaderPrice,
vendor_Dtls.VNDNAM as BillingHeaderVendorName,

detail.DTLCOD  as BillingbodyDTLCOD,
detail.ITMPRC  as BillingbodyItemPrice,
detail.ITMQTY  as BillingbodyItemQty,
itemdet.ITMNAM as BillingbodyItemName
 

from BILDTLs  as detail
join BILHDRs as header
on detail.BILCOD=header.BILCOD
join ITMDTLs as itemdet
on detail.ITMCOD=itemdet.ITMCOD
join VNDDTLs as vendor_Dtls
on header.VNDCOD=vendor_Dtls.VNDCOD
where header.BILCOD=@Id


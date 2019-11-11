select sum(orden_h.total)as total_mes ,EXTRACT (MONTH from documento.fecha) from orden_h 
JOIN documento 
ON orden_h.DOCUMENTO_ID = documento.id
GROUP BY EXTRACT (MONTH from documento.fecha) 
order by sum(orden_h.total) desc

-- mes con mas ingresos
select max(total_mes) from (select sum(orden_h.total)as total_mes ,EXTRACT (MONTH from documento.fecha) as mes from orden_h 
JOIN documento 
ON orden_h.DOCUMENTO_ID = documento.id
GROUP BY EXTRACT (MONTH from documento.fecha) 
order by sum(orden_h.total) desc) 

drop function FN_MES_CON_MAS_INGRESOS

CREATE OR REPLACE FUNCTION FN_TOTAL_DE_INGRESOS_MES_MAS_INGRESO
RETURN NUMERIC
IS 
    V_TOTAL NUMERIC;   
BEGIN
    select max(total_mes) into V_TOTAL from (select sum(orden_h.total)as total_mes ,EXTRACT (MONTH from documento.fecha) as mes from orden_h 
    JOIN documento 
    ON orden_h.DOCUMENTO_ID = documento.id
    GROUP BY EXTRACT (MONTH from documento.fecha) 
    order by sum(orden_h.total) desc) ;
    return V_TOTAL;
END ;

CREATE OR REPLACE FUNCTION FN_MES_CON_MAS_INGRESOS 
RETURN NUMERIC
IS
    V_MES NUMERIC;
    V_TOTAL NUMERIC;
BEGIN
    V_TOTAL:= FN_TOTAL_DE_INGRESOS_MES_MAS_INGRESO();
    select mes into V_MES from (select sum(orden_h.total)as total_mes ,EXTRACT (MONTH from documento.fecha) as mes from orden_h 
    JOIN documento 
    ON orden_h.DOCUMENTO_ID = documento.id
    GROUP BY EXTRACT (MONTH from documento.fecha) 
    order by sum(orden_h.total) desc) where total_mes = V_TOTAL;
    RETURN V_MES;
END;



declare 
    total number;
begin
    total:= FN_TOTAL_DE_INGRESOS_MES_MAS_INGRESO();
    DBMS_OUTPUT.put_line(total);
end;


declare  
    mes number;
begin
    mes:= FN_MES_CON_MAS_INGRESOS();
    DBMS_OUTPUT.put_line(mes);
end;


DECLARE
     total number;
     mes number;  
BEGIN
    total:= FN_TOTAL_DE_INGRESOS_MES_MAS_INGRESO();
    mes:= FN_MES_CON_MAS_INGRESOS();
    DBMS_OUTPUT.put_line(CAST(mes as VARCHAR2) || ' | ' || CAST(total as VARCHAR2));
END;
 
 
 
 
 SET serveroutput ON
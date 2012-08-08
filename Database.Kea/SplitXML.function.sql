CREATE FUNCTION [dbo].[SplitXML] (@sep VARCHAR(32), @s VARCHAR(MAX))

RETURNS @t TABLE
    (
        val VARCHAR(MAX)
    )   
AS
    BEGIN
        DECLARE @xml XML
        SET @XML = N'<root><r>' + REPLACE(@s, @sep, '</r><r>') + '</r></root>'

        INSERT INTO @t(val)
        SELECT r.value('.','VARCHAR(5)') as Item
        FROM @xml.nodes('//root/r') AS RECORDS(r)

        RETURN
    END
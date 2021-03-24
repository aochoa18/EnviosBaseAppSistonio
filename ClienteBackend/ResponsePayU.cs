using System;

namespace ClienteBackend
{
    public class ResponsePayU
    {
        /// <summary>
        /// Es el número identificador del comercio en el sistema de PayU, este número lo encontrará en el correo de creación de la cuenta.
        /// </summary>
        public int? merchant_id { get; set; }
        /// <summary>
        /// Indica el estado de la transacción en el sistema.
        /// </summary>
        public string state_pol { get; set; }
        /// <summary>
        /// El riesgo asociado a la transacción. Toma un valor entre 0 y 1. A mayor riesgo mayor valor. Viene en formato ###.00
        /// </summary>
        public decimal? risk { get; set; }
        /// <summary>
        /// El código de respuesta de PayU.
        /// </summary>
        public string response_code_pol { get; set; }
        /// <summary>
        /// Es la referencia de la venta o pedido. Deber ser único por cada transacción que se envía al sistema.
        /// </summary>
        public string reference_sale { get; set; }
        /// <summary>
        /// Alfa numérico   255	La referencia o número de la transacción generado en PayU.
        /// </summary>
        public string reference_pol { get; set; }
        /// <summary>
        /// Alfa numérico   255	Es la firma digital creada para cada uno de las transacciones.
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// Alfa numérico   255	Campo adicional para enviar información sobre la compra.Ej.Descripción de la compra en caso de querer visualizarla en la página de confirmación.
        /// </summary>
        public string extra1 { get; set; }
        /// <summary>
        /// Alfa numérico   255	Campo adicional para enviar información sobre la compra. Ej.Códigos internos de los productos.
        /// </summary>
        public string extra2 { get; set; }
        /// <summary>
        /// Numérico	—	El identificador interno del medio de pago utilizado.
        /// </summary>
        public int? payment_method { get; set; }
        /// <summary>
        /// Numérico	—	El tipo de medio de pago utilizado para el pago
        /// </summary>
        public int? payment_method_type { get; set; }
        /// <summary>
        /// Numérico	—	Número de cuotas en las cuales se difirió el pago con tarjeta crédito.
        /// </summary>
        public int? installments_number { get; set; }
        /// <summary>
        /// Numérico	14,2	Es el monto total de la transacción.Puede contener dos dígitos decimales.Ej. 10000.00 ó 10000
        /// </summary>
        public float? value { get; set; }
        /// <summary>
        /// Numérico	14,2	Es el valor del IVA de la transacción, si se envía el IVA nulo el sistema aplicará el 19% automáticamente.Puede contener dos dígitos decimales.Ej: 19000.00. En caso de no tener IVA debe enviarse en 0.
        /// </summary>
        public float? tax { get; set; }
        /// <summary>
        /// Numérico	14,2	Valor Adicional no comisionable.
        /// </summary>
        public float? additional_value { get; set; }
        /// <summary>
        /// Fecha (YYYY-MM-DD HH:mm:ss) —	La fecha en que se realizó la transacción.
        /// </summary>
        public DateTime? transaction_date { get; set; }
        /// <summary>
        /// Alfa numérico	3	La moneda respectiva en la que se realiza el pago. El proceso de conciliación se hace en pesos a la tasa representativa del día.
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// Alfa numérico   255	Campo que contiene el correo electrónico del comprador para notificarle el resultado de la transacción por correo electrónico. Se recomienda hacer una validación si se toma este dato en un formulario.
        /// </summary>
        public string email_buyer { get; set; }
        ///Alfa numérico   64	El cus, código único de seguimiento, es la referencia del pago dentro del Banco, aplica solo para pagos con PSE
        public string cus { get; set; }
        /// <summary>
        /// Alfa numérico   255	El nombre del banco, aplica solo para pagos con PSE.
        /// </summary>
        public string stringpse_bank { get; set; }
        /// <summary>
        /// Lógico(true, false)    —	Variable para poder identificar si la operación fue una prueba.
        /// </summary>
        public string test { get; set; }
        /// <summary>
        /// Alfa numérico	255	Es la descripción de la venta.
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// Alfa numérico   255	La dirección de facturación
        /// </summary>
        public string billing_address { get; set; }
        /// <summary>
        /// Alfa numérico   50	La dirección de entrega de la mercancía.
        /// </summary>
        public string shipping_address { get; set; }
        /// <summary>
        /// Alfa numérico   20	El teléfono de residencia del comprador.
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// Alfa numérico   20	El teléfono diurno del comprador.
        /// </summary>
        public string office_phone { get; set; }
        /// <summary>
        /// Alfa numérico   36	Identificador de la transacción.
        /// </summary>
        public string account_number_ach { get; set; }
        /// <summary>
        /// Alfa numérico   36	Identificador de la transacción.
        /// </summary>
        public string account_type_ach { get; set; }
        /// <summary>
        /// Decimal (#.00)	—	Valor de la tarifa administrativa
        /// </summary>
        public decimal? administrative_fee { get; set; }
        /// <summary>
        /// Decimal (#.00)	—	Valor base de la tarifa administrativa
        /// </summary>
        public decimal? administ0rative_fee_base { get; set; }
        /// <summary>
        /// Decimal (#.00)	—	Valor del impuesto de la tarifa administrativa
        /// </summary>
        public decimal? administrative_fee_tax { get; set; }
        /// <summary>
        /// Alfa numérico	4	Código de la aerolínea
        /// </summary>
        public int? airline_code { get; set; }
        /// <summary>
        /// Numérico	—	Numero de intentos del envío de la confirmación.
        /// </summary>
        public int? attempts { get; set; }
        /// <summary>
        /// Alfa numérico   12	Código de autorización de la venta
        /// </summary>
        public string authorization_code { get; set; }
        /// <summary>
        /// Alfa numérico   12	Código de autorización de la agencia de viajes
        /// </summary>
        public string travel_agency_authorization_code { get; set; }
        /// <summary>
        /// Alfa numérico   255	Identificador del banco
        /// </summary>
        public string bank_id { get; set; }
        /// <summary>
        /// Alfa numérico	255	La ciudad de facturación.
        /// </summary>
        public string billing_city { get; set; }
        /// <summary>
        /// Alfa numérico   2	El código ISO del país asociado a la dirección de facturación.
        /// </summary>
        public string billing_country { get; set; }
        /// <summary>
        /// Decimal (#.00)	—	Valor de la comisión
        /// </summary>
        public decimal? commision_pol { get; set; }
        /// <summary>
        /// Alfa numérico	3	Moneda de la comisión
        /// </summary>
        public string commision_pol_currency { get; set; }
        /// <summary>
        /// Numérico	—	Numero de cliente.
        /// </summary>
        public int? customer_number { get; set; }
        /// <summary>
        /// Fecha (YYYY-MM-DD HH:mm:ss) —	Fecha de la operación.
        /// </summary>
        public DateTime? date { get; set; }
        /// <summary>
        /// Alfa numérico	255	Código de error del banco.
        /// </summary>
        public string error_code_bank { get; set; }
        /// <summary>
        /// Alfa numérico   255	Mensaje de error del banco
        /// </summary>
        public string error_message_bank { get; set; }
        /// <summary>
        /// Decimal (#.00)	—	Valor de la tasa de cambio.
        /// </summary>
        public decimal? exchange_rate { get; set; }
        /// <summary>
        /// Alfa numérico	39	Dirección ip desde donde se realizó la transacción.
        /// </summary>
        public string ip { get; set; }
        /// <summary>
        /// Alfa numérico   150	Nombre corto del comprador.
        /// </summary>
        public string nickname_buyer { get; set; }
        /// <summary>
        /// Alfa numérico   150	Nombre corto del vendedor.
        /// </summary>
        public string nickname_seller { get; set; }
        /// <summary>
        /// Numérico	—	Identificador del medio de pago.
        /// </summary>
        public string payment_method_id { get; set; }
        /// <summary>
        /// Alfa numérico   32	Estado de la solicitud de pago.
        /// </summary>
        public string payment_request_state { get; set; }
        /// <summary>
        /// Alfa numérico   255	Referencia no. 1 para pagos con PSE.
        /// </summary>
        public string pseReference1 { get; set; }
        /// <summary>
        /// Alfa numérico   255	Referencia no. 2 para pagos con PSE.
        /// </summary>
        public string pseReference2 { get; set; }
        /// <summary>
        /// Alfa numérico   255	Referencia no. 3 para pagos con PSE.
        /// </summary>
        public string pseReference3 { get; set; }
        /// <summary>
        /// Alfa numérico   255	El mensaje de respuesta de PAYU.
        /// </summary>
        public string response_message_pol { get; set; }
        /// <summary>
        /// Alfa numérico   50	La ciudad de entrega de la mercancía.
        /// </summary>
        public string shipping_city { get; set; }
        /// <summary>
        /// Alfa numérico   2	El código ISO asociado al país de entrega de la mercancía.
        /// </summary>
        public string shipping_country { get; set; }
        /// <summary>
        /// Alfa numérico   255	Identificador de la transacción en el sistema del banco.
        /// </summary>
        public string transaction_bank_id { get; set; }
        /// <summary>
        /// Alfa numérico   36	Identificador de la transacción.
        /// </summary>
        public string transaction_id { get; set; }
        /// <summary>
        /// Alfa numérico   255	Medio de pago con el cual se hizo el pago. Por ejemplo VISA.
        /// </summary>
        public string payment_method_name { get; set; }
    }
}

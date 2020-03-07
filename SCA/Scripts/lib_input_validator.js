function isNull(v)
{
	return v.search(/\S+/) == -1;
}

function isInteger(v)
{
	return v.search(/^\d+$/) != -1;
}

function isFloat(v, s, mind, maxd)
{
	var
		sep = (arguments.length > 1) ? s : ",",
		mindec = (arguments.length > 2) ? mind : "0",
		maxdec = (arguments.length > 3) ? maxd : "1000",
		r = new RegExp("^(\\d+)?(\\" + sep + "{1}(\\d{" + mindec + "," + maxdec + "}))?$");
		
	if (isNull(v)) return false;
	else return v.search(r) != -1;
}

function isMoney(v, ds, ts, mind, maxd)
{
	var 
		dsep = (arguments.length > 1) ? ds : ",",
		tsep = (arguments.length > 2) ? ts : ".",
		mindec = (arguments.length > 3) ? mind : "2",
		maxdec = (arguments.length > 4) ? maxd : "4",
		r = new RegExp("^(\\d{1,3})?(\\" + tsep + "\\d{3})*(\\" + dsep + "{1}\\d{" + mindec + "," + maxdec + "})?$");

	if (isNull(v)) return false;
	else return v.search(r) != -1;
}

function isURL(v)
{
	return v.search(/(ftp|http|https):\/\/(\w+:{0,1}\w*@)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))?/) != -1;		
}

function stringToFloat(v, s)
{
	var
		sep = (arguments.length > 1) ? ds : ",",
		sep2 = (sep = ".") ? "," : ".";
		
		
	v = v.replace(sep, sep2);
	
	return parseFloat(v);
}

function IsNotNullCondition(property)
{
	this.field = null;
	this.property = property;
	
	this.validate = function()
	{
		var 
			p = eval(this.field.fieldName + "." + this.property);
			
		return !isNull(p);
	}
}

function LengthCondition(property, length1, length2)
{
	this.field = null;
	this.property = property;
	this.length1 = length1;
	this.length2 = length2;
	
	this.validate = function()
	{
		var l = eval(this.field.fieldName + "." + this.property + ".length");
		
		if (typeof(this.length2) == "undefined")
		{
			return l == this.length1;
		}
		else
		{
			return (l >= this.length1) && (l <= this.length2);
		}
	}
}

function IsIntegerCondition(property)
{
	this.field = null;
	this.property = property;
	
	this.validate = function()
	{
		var 
			p = eval(this.field.fieldName + "." + this.property);
			
		return isInteger(p);
	}
}

function IsURLCondition(property)
{
	this.field = null;
	this.property = property;
	
	this.validate = function()
	{
		var 
			p = eval(this.field.fieldName + "." + this.property);
			
		return isURL(p);
	}
}

function IsFloatCondition(property, sep, mindec, maxdec)
{
	this.field = null;
	this.property = property;
	this.sep = (arguments.length > 1) ? sep : ",";
	this.mindec = mindec;
	this.maxdec = maxdec;
	
	this.validate = function()
	{
		var 
			p = eval(this.field.fieldName + "." + this.property);

		return isFloat(p, this.sep, this.mindec, this.maxdec);
	}
}

function IsMoneyCondition(property, dsep, tsep, mindec, maxdec)
{
	this.field = null;
	this.property = property;
	this.dsep = (arguments.length > 1) ? dsep : ",";
	this.tsep = (arguments.length > 2) ? tsep : ".";
	this.mindec = (arguments.length > 3) ? mindec : "2";
	this.maxdec = (arguments.length > 4) ? maxdec : "4";
	
	
	this.validate = function()
	{
		var 
			p = eval(this.field.fieldName + "." + this.property);

		return isMoney(p, this.dsep, this.tsep, this.mindec, this.maxdec);
	}
}

function IsTimeCondition(property)
{
	this.field = null;
	this.property = property;
	
	this.validate = function()
	{
		var 
			p = eval(this.field.fieldName + "." + this.property);
			
		return dateFunctions.isTime(p);
	}
}

function IsDateCondition(property)
{
	this.field = null;
	this.property = property;
	
	this.validate = function()
	{
		var 
			p = eval(this.field.fieldName + "." + this.property);
			
		return dateFunctions.isDate(p);
	}
}

function FunctionCondition(property, func)
{
	this.field = null;
	this.property = property;
	this.func = func;
	
	this.validate = function()
	{
		return this.func(eval(this.field.fieldName + "." + this.property));
	}
}

function ExpressionCondition(p1, p2)
{
	this.field = null;
	if (arguments.length > 1)
	{
		this.property = p1;
		this.expression = p2;
	}
	else
	{
		this.property = null;	
		this.expression = p1;	
	}
	
	this.validate = function()
	{
		var	t;
		if (this.property == null)
		{			
			t = this.field.fieldName;
		}
		else
		{
			t = this.field.fieldName + "." + this.property;							
		}
		return eval(this.expression.replace(/\{t\}/g, t));
	}
}

function IsEmailCondition(property)
{
	this.field = null;
	this.property = property;
	
	this.validate = function()
	{
		var
			p = eval(this.field.fieldName + "." + this.property);
			
		return p.search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/) != -1;
	}
}

function InputField(fieldName, isRequired, requireCondition)
{
	this.fieldName = fieldName;
	this.isRequired = isRequired;
	this.requireCondition = requireCondition;
	this.conditions = [];
	this.action = null;
	this.currentCondition = null;
	
	if (this.requireCondition != null)
	{
		this.requireCondition.field = this;
	}
	
	this.defaultAction = function(message)
	{
		var
			f = eval(this.fieldName);
			
			alert(this.currentCondition[1]);
			if(f != null)
			{
				if (!f.disabled)
				{
					if ((navigator.appName == 'Netscape') || (navigator.appVersion.indexOf('MSIE 4') != -1))
						eval("f.focus();")
					else
						eval("try { f.focus(); } catch(e) { };");
				}
			}
	}
	
	this.addCondition = function(condition, errorMessage)
	{
		this.conditions[this.conditions.length] = new Array(condition, errorMessage);
		condition.field = this;
	}
	
	this.validate = function()
	{
		if (!this.isRequired || this.requireCondition != null)
		{
			if (!requireCondition.validate())
			{
				return true;
			}
		}
		if (this.isRequired && this.conditions.length == 0)
		{
			alert("Required field \"" + this.fieldName + "\" doesn't have any associated condition.");
			return false;
		}
		for (var i = 0; i < this.conditions.length; i++)
		{
			this.currentCondition = this.conditions[i];
			if (!this.currentCondition[0].validate()) 
			{
				if (this.action != null)
				{
					if (typeof(this.action) == "function")
					{
						this.action();
					}
					else
					{
						eval(this.action);
					}
				}
				else
				{
					this.defaultAction();
				}
				return false;
			}
		}
		return true;
	}
}

function InputRule()
{
	this.rule = null;
	this.action = null;	
	
	this.validate = function()
	{
		if (this.rule != null) 
		{
			if (!this.rule())
			{
				if (this.action != null)
				{
					if (typeof(this.action) == "function")
					{
						this.action();
					}
					else
					{
						eval(this.action);
					}
				}
				return false;
			}
			return true;
		}
		else
		{
			alert("Rule doesn't have associated function.");
		}
	}
}

function InputValidator()
{
	this.objects = [];

	this.addRule = function()
	{
		var rule = new InputRule;
		
		this.objects[this.objects.length] = rule;
		return rule;
	}
	
	this.addRequiredField = function(fieldName, condition)
	{
		var field = new InputField(fieldName, true, (arguments.length > 1) ? condition : null);
		
		this.objects[this.objects.length] = field;
		return field;
	}
	
	this.addOptionalField = function(fieldName, condition)
	{
		var field = new InputField(fieldName, false, condition);

		this.objects[this.objects.length] = field;
		return field;
	}
	
	this.validate = function()
	{
		for (var i = 0; i < this.objects.length; i++)
		{
			if (!this.objects[i].validate()) 
			{
				return false;
			}
		}
		return true;
	}
}

function checkCNPJ(value)
{
	return CGC_OK(value) 
}

function CGC_OK(Numero_CGC) 
{
  var Parcela;
  var Quociente;
  var Resto;
  var Soma;
  var Fator;
  var I;
  var C1;
  var C2;
  var dv1;
  var dv2;
	
  //Verificação dos dois digitos finais em relação ao número completo
  C1 = parseInt(Numero_CGC.substring(12, 13), 10);  //13º caracter = primeiro dígito verificador
  C2 = parseInt(Numero_CGC.substring(13, 14), 10);  //14º caracter = segundo dígito verificador
	
  //Verificação do primeiro dígito (C1)
  Soma = 0;
  Parcela = 0;
  Fator = 0;
	
  for(I=1; I<=12; I++)
  {
	if(I < 9)
	{
	  Fator = I + 1;
	}
	else
	{
	  Fator = I - 7;
	}

	Parcela = Fator * parseInt(Numero_CGC.substring(12 - I, 12 - I + 1), 10);
	Soma = Soma + Parcela;
  } //fechando o "for".
	
  dv1 = (Soma % 11); 
  dv1 = 11 - dv1;

  if(dv1 > 9)
  {
	dv1 = 0;
  }
	
  if(C1 != dv1)
  {
	return false;
  }
	
  //Verificação do segundo dígito (C2)
  Soma = 0;
  Parcela = 0;
  Fator = 0;

  for(I=1; I<=13; I++)
  {
	 if(I < 9)
	 {
		Fator = I + 1;
	 }	  
	 else
	 {
	   Fator = I - 7;
	 }	  
	 Parcela = Fator * parseInt(Numero_CGC.substring(13 - I, 13 - I + 1), 10);
	 Soma = Soma + Parcela;
  }
	 
  dv2 = (Soma % 11);
  dv2 = 11 - dv2;
  
  if(dv2 > 9)
  {
	dv2 = 0;
  }

  if(C2 != dv2)
  {
	return false;
  }
  
	return true;
}	

function SohNumeros(campo)
{
	var digits="0123456789"
	var campo_temp 
	for (var i=0;i<campo.value.length;i++)
	{
		campo_temp=campo.value.substring(i,i+1)	
		if (digits.indexOf(campo_temp)==-1)
		{
			campo.value = campo.value.substring(0,i);
			break;
		}
	}
}

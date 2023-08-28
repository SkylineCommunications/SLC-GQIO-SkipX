/*
****************************************************************************
*  Copyright (c) 2023,  Skyline Communications NV  All Rights Reserved.    *
****************************************************************************

By using this script, you expressly agree with the usage terms and
conditions set out below.
This script and all related materials are protected by copyrights and
other intellectual property rights that exclusively belong
to Skyline Communications.

A user license granted for this script is strictly for personal use only.
This script may not be used in any way by anyone without the prior
written consent of Skyline Communications. Any sublicensing of this
script is forbidden.

Any modifications to this script by the user are only allowed for
personal use and within the intended purpose of the script,
and will remain the sole responsibility of the user.
Skyline Communications will not be responsible for any damages or
malfunctions whatsoever of the script resulting from a modification
or adaptation by the user.

The content of this script is confidential information.
The user hereby agrees to keep this confidential information strictly
secret and confidential and not to disclose or reveal it, in whole
or in part, directly or indirectly to any person, entity, organization
or administration without the prior written consent of
Skyline Communications.

Any inquiries can be addressed to:

	Skyline Communications NV
	Ambachtenstraat 33
	B-8870 Izegem
	Belgium
	Tel.	: +32 51 31 35 69
	Fax.	: +32 51 31 01 29
	E-mail	: info@skyline.be
	Web		: www.skyline.be
	Contact	: Ben Vandenberghe

****************************************************************************
Revision History:

DATE		VERSION		AUTHOR			COMMENTS

28/08/2023	1.0.0.1		MOD, Skyline	Initial version
****************************************************************************
*/

namespace SkipX_1
{
	using Skyline.DataMiner.Analytics.GenericInterface;

	[GQIMetaData(Name = "Skip X")]
	public class SkipX : IGQIRowOperator, IGQIInputArguments
	{
		private GQIIntArgument _skipXArg = new GQIIntArgument("X") { IsRequired = true };
		private int _skipX;

		public void HandleRow(GQIEditableRow row)
		{
			if (_skipX != 0)
			{
				// Remove row until no more need to be deleted.
				_skipX--;
				row.Delete();
			}
		}

		public GQIArgument[] GetInputArguments()
		{
			return new GQIArgument[]
			{
				_skipXArg
			};
		}

		public OnArgumentsProcessedOutputArgs OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)
		{
			_skipX = args.GetArgumentValue(_skipXArg);

			return new OnArgumentsProcessedOutputArgs();
		}
	}
}
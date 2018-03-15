//
// --------------------------------------------------------------------------
//  Gurux Ltd
//
//
//
// Filename:        $HeadURL$
//
// Version:         $Revision$,
//                  $Date$
//                  $Author$
//
// Copyright (c) Gurux Ltd
//
//---------------------------------------------------------------------------
//
//  DESCRIPTION
//
// This file is a part of Gurux Device Framework.
//
// Gurux Device Framework is Open Source software; you can redistribute it
// and/or modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; version 2 of the License.
// Gurux Device Framework is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU General Public License for more details.
//
// More information of Gurux products: http://www.gurux.org
//
// This code is licensed under the GNU General Public License v2.
// Full text may be retrieved at http://www.gnu.org/licenses/gpl-2.0.txt
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Gurux.DLMS.Internal;
using Gurux.DLMS.Enums;

namespace Gurux.DLMS.Objects
{
    /// <summary>
    /// Online help:
    /// http://www.gurux.fi/Gurux.DLMS.Objects.GXDLMSLimiter
    /// </summary>
    public class GXDLMSLimiter : GXDLMSObject, IGXDLMSBase
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public GXDLMSLimiter()
        : this("0.0.17.0.0.255", 0)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="ln">Logical Name of the object.</param>
        public GXDLMSLimiter(string ln)
        : this(ln, 0)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="ln">Logical Name of the object.</param>
        /// <param name="sn">Short Name of the object.</param>
        public GXDLMSLimiter(string ln, ushort sn)
        : base(ObjectType.Limiter, ln, sn)
        {
            EmergencyProfile = new GXDLMSEmergencyProfile();
            ActionOverThreshold = new GXDLMSActionItem();
            ActionUnderThreshold = new GXDLMSActionItem();
        }

        /// <summary>
        /// Defines an attribute of an object to be monitored.
        /// </summary>
        [XmlIgnore()]
        public GXDLMSObject MonitoredValue
        {
            get;
            set;
        }

        /// <summary>
        /// Attribute index of monitored value.
        /// </summary>
        [XmlIgnore()]
        public int MonitoredAttributeIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Provides the active threshold value to which the attribute monitored is compared.
        /// </summary>
        public object ThresholdActive
        {
            get;
            set;
        }

        /// <summary>
        /// Provides the threshold value to which the attribute monitored
        /// is compared when in normal operation.
        /// </summary>
        public object ThresholdNormal
        {
            get;
            set;
        }

        /// <summary>
        /// Provides the threshold value to which the attribute monitored
        /// is compared when an emergency profile is active.
        /// </summary>
        public object ThresholdEmergency
        {
            get;
            set;
        }

        /// <summary>
        /// Defines minimal over threshold duration in seconds required
        /// to execute the over threshold action.
        /// </summary>
        public UInt32 MinOverThresholdDuration
        {
            get;
            set;
        }

        /// <summary>
        /// Defines minimal under threshold duration in seconds required to
        /// execute the under threshold action.
        /// </summary>
        public UInt32 MinUnderThresholdDuration
        {
            get;
            set;
        }

        public GXDLMSEmergencyProfile EmergencyProfile
        {
            get;
            set;
        }

        public UInt16[] EmergencyProfileGroupIDs
        {
            get;
            set;
        }

        /// <summary>
        /// Is Emergency Profile active.
        /// </summary>
        public bool EmergencyProfileActive
        {
            get;
            set;
        }

        /// <summary>
        /// Defines the scripts to be executed when the monitored value
        /// crosses the threshold for minimal duration time.
        /// </summary>
        public GXDLMSActionItem ActionOverThreshold
        {
            get;
            set;
        }

        /// <summary>
        /// Defines the scripts to be executed when the monitored value
        /// crosses the threshold for minimal duration time.
        /// </summary>
        public GXDLMSActionItem ActionUnderThreshold
        {
            get;
            set;
        }



        /// <inheritdoc cref="GXDLMSObject.GetValues"/>
        public override object[] GetValues()
        {
            return new object[] { LogicalName, MonitoredValue, ThresholdActive, ThresholdNormal, ThresholdEmergency,
                              MinOverThresholdDuration, MinUnderThresholdDuration, EmergencyProfile, EmergencyProfileGroupIDs,
                              EmergencyProfileActive, new object[] {ActionOverThreshold, ActionUnderThreshold}
                            };
        }

        #region IGXDLMSBase Members

        byte[] IGXDLMSBase.Invoke(GXDLMSSettings settings, ValueEventArgs e)
        {
            e.Error = ErrorCode.ReadWriteDenied;
            return null;
        }

        int[] IGXDLMSBase.GetAttributeIndexToRead(bool all)
        {
            List<int> attributes = new List<int>();
            //LN is static and read only once.
            if (all || string.IsNullOrEmpty(LogicalName))
            {
                attributes.Add(1);
            }
            //MonitoredValue
            if (all || CanRead(2))
            {
                attributes.Add(2);
            }

            //ThresholdActive
            if (all || CanRead(3))
            {
                attributes.Add(3);
            }

            //ThresholdNormal
            if (all || CanRead(4))
            {
                attributes.Add(4);
            }

            //ThresholdEmergency
            if (all || CanRead(5))
            {
                attributes.Add(5);
            }

            //MinOverThresholdDuration
            if (all || CanRead(6))
            {
                attributes.Add(6);
            }

            //MinUnderThresholdDuration
            if (all || CanRead(7))
            {
                attributes.Add(7);
            }

            //EmergencyProfile
            if (all || CanRead(8))
            {
                attributes.Add(8);
            }
            //EmergencyProfileGroup
            if (all || CanRead(9))
            {
                attributes.Add(9);
            }

            //EmergencyProfileActive
            if (all || CanRead(10))
            {
                attributes.Add(10);
            }
            //Actions
            if (all || CanRead(11))
            {
                attributes.Add(11);
            }
            return attributes.ToArray();
        }

        /// <inheritdoc cref="IGXDLMSBase.GetNames"/>
        string[] IGXDLMSBase.GetNames()
        {
            return new string[] {Internal.GXCommon.GetLogicalNameString(), "Monitored Value",
                             "Active Threshold", "Normal Threshold", "Emergency Threshold", "Threshold Duration Min Over",
                             "Threshold Duration Min Under", "Emergency Profile", "Emergency Profile Group",
                             "Emergency Profile Active", "Actions"
                            };
        }

        int IGXDLMSBase.GetAttributeCount()
        {
            return 11;
        }

        int IGXDLMSBase.GetMethodCount()
        {
            return 0;
        }

        /// <inheritdoc cref="IGXDLMSBase.GetDataType"/>
        public override DataType GetDataType(int index)
        {
            if (index == 1)
            {
                return DataType.OctetString;
            }
            if (index == 2)
            {
                return DataType.Structure;
            }
            if (index == 3)
            {
                return base.GetDataType(index);
            }
            if (index == 4)
            {
                return base.GetDataType(index);
            }
            if (index == 5)
            {
                return base.GetDataType(index);
            }
            if (index == 6)
            {
                return DataType.UInt32;
            }
            if (index == 7)
            {
                return DataType.UInt32;
            }
            if (index == 8)
            {
                return DataType.Structure;
            }
            if (index == 9)
            {
                return DataType.Array;
            }
            if (index == 10)
            {
                return DataType.Boolean;
            }
            if (index == 11)
            {
                return DataType.Structure;
            }
            throw new ArgumentException("GetDataType failed. Invalid attribute index.");
        }

        object IGXDLMSBase.GetValue(GXDLMSSettings settings, ValueEventArgs e)
        {
            if (e.Index == 1)
            {
                return GXCommon.LogicalNameToBytes(LogicalName);
            }
            else if (e.Index == 2)
            {
                GXByteBuffer data = new GXByteBuffer();
                data.SetUInt8((byte)DataType.Structure);
                data.SetUInt8(3);
                if (MonitoredValue == null)
                {
                    GXCommon.SetData(settings, data, DataType.Int16, 0);
                    GXCommon.SetData(settings, data, DataType.OctetString, GXCommon.LogicalNameToBytes(null));
                    GXCommon.SetData(settings, data, DataType.UInt8, 0);
                }
                else
                {
                    GXCommon.SetData(settings, data, DataType.Int16, MonitoredValue.ObjectType);
                    GXCommon.SetData(settings, data, DataType.OctetString, GXCommon.LogicalNameToBytes(MonitoredValue.LogicalName));
                    GXCommon.SetData(settings, data, DataType.UInt8, MonitoredAttributeIndex);

                }
                return data.Array();
            }
            else if (e.Index == 3)
            {
                return ThresholdActive;
            }
            else if (e.Index == 4)
            {
                return ThresholdNormal;
            }
            else if (e.Index == 5)
            {
                return ThresholdEmergency;
            }
            else if (e.Index == 6)
            {
                return MinOverThresholdDuration;
            }
            else if (e.Index == 7)
            {
                return MinUnderThresholdDuration;
            }
            else if (e.Index == 8)
            {
                GXByteBuffer data = new GXByteBuffer();
                data.SetUInt8((byte)DataType.Structure);
                data.SetUInt8(3);
                GXCommon.SetData(settings, data, DataType.UInt16, EmergencyProfile.ID);
                GXCommon.SetData(settings, data, DataType.OctetString, EmergencyProfile.ActivationTime);
                GXCommon.SetData(settings, data, DataType.UInt32, EmergencyProfile.Duration);
                return data.Array();
            }
            else if (e.Index == 9)
            {
                GXByteBuffer data = new GXByteBuffer();
                data.SetUInt8((byte)DataType.Array);
                if (EmergencyProfileGroupIDs == null)
                {
                    data.SetUInt8(0);
                }
                else
                {
                    data.SetUInt8((byte)EmergencyProfileGroupIDs.Length);
                    foreach (object it in EmergencyProfileGroupIDs)
                    {
                        GXCommon.SetData(settings, data, DataType.UInt16, it);
                    }
                }

                return data.Array();
            }
            else if (e.Index == 10)
            {
                return EmergencyProfileActive;
            }
            else if (e.Index == 11)
            {
                GXByteBuffer data = new GXByteBuffer();
                data.SetUInt8((byte)DataType.Structure);
                data.SetUInt8(2);
                data.SetUInt8((byte)DataType.Structure);
                data.SetUInt8(2);
                GXCommon.SetData(settings, data, DataType.OctetString, GXCommon.LogicalNameToBytes(ActionOverThreshold.LogicalName));
                GXCommon.SetData(settings, data, DataType.UInt16, ActionOverThreshold.ScriptSelector);
                data.SetUInt8((byte)DataType.Structure);
                data.SetUInt8(2);
                GXCommon.SetData(settings, data, DataType.OctetString, GXCommon.LogicalNameToBytes(ActionUnderThreshold.LogicalName));
                GXCommon.SetData(settings, data, DataType.UInt16, ActionUnderThreshold.ScriptSelector);
                return data.Array();
            }
            e.Error = ErrorCode.ReadWriteDenied;
            return null;
        }

        void IGXDLMSBase.SetValue(GXDLMSSettings settings, ValueEventArgs e)
        {
            if (e.Index == 1)
            {
                LogicalName = GXCommon.ToLogicalName(e.Value);
            }
            else if (e.Index == 2)
            {
                ObjectType ot = (ObjectType)Convert.ToInt16(((object[])e.Value)[0]);
                string ln = GXCommon.ToLogicalName(((object[])e.Value)[1]);
                int attIndex = Convert.ToInt32(((object[])e.Value)[2]);
                MonitoredValue = settings.Objects.FindByLN(ot, ln);
                MonitoredAttributeIndex = attIndex;
            }
            else if (e.Index == 3)
            {
                ThresholdActive = e.Value;
            }
            else if (e.Index == 4)
            {
                ThresholdNormal = e.Value;
            }
            else if (e.Index == 5)
            {
                ThresholdEmergency = e.Value;
            }
            else if (e.Index == 6)
            {
                MinOverThresholdDuration = Convert.ToUInt32(e.Value);
            }
            else if (e.Index == 7)
            {
                MinUnderThresholdDuration = Convert.ToUInt32(e.Value);
            }
            else if (e.Index == 8)
            {
                object[] tmp = (object[])e.Value;
                EmergencyProfile.ID = (UInt16)tmp[0];
                EmergencyProfile.ActivationTime = (GXDateTime)GXDLMSClient.ChangeType((byte[])tmp[1], DataType.DateTime, settings.UseUtc2NormalTime);
                EmergencyProfile.Duration = (UInt32)tmp[2];
            }
            else if (e.Index == 9)
            {
                List<UInt16> list = new List<UInt16>();
                if (e.Value != null)
                {
                    foreach (object it in (object[])e.Value)
                    {
                        list.Add(Convert.ToUInt16(it));
                    }
                }
                EmergencyProfileGroupIDs = list.ToArray();
            }
            else if (e.Index == 10)
            {
                EmergencyProfileActive = Convert.ToBoolean(e.Value);
            }
            else if (e.Index == 11)
            {
                object[] tmp = (object[])e.Value;
                object[] tmp1 = (object[])tmp[0];
                object[] tmp2 = (object[])tmp[1];
                ActionOverThreshold.LogicalName = GXCommon.ToLogicalName(tmp1[0]);
                ActionOverThreshold.ScriptSelector = Convert.ToUInt16(tmp1[1]);
                ActionUnderThreshold.LogicalName = GXCommon.ToLogicalName((byte[])tmp2[0]);
                ActionUnderThreshold.ScriptSelector = Convert.ToUInt16(tmp2[1]);
            }
            else
            {
                e.Error = ErrorCode.ReadWriteDenied;
            }
        }

        void IGXDLMSBase.Load(GXXmlReader reader)
        {
            if (reader.IsStartElement("MonitoredValue", true))
            {
                ObjectType ot = (ObjectType)reader.ReadElementContentAsInt("ObjectType");
                string ln = reader.ReadElementContentAsString("LN");
                if (ot != ObjectType.None && ln != null)
                {
                    MonitoredValue = reader.Objects.FindByLN(ot, ln);
                    //If item is not serialized yet.
                    if (MonitoredValue == null)
                    {
                        MonitoredValue = GXDLMSClient.CreateObject(ot);
                        MonitoredValue.LogicalName = ln;
                    }
                }
                reader.ReadEndElement("MonitoredValue");
            }
            ThresholdActive = reader.ReadElementContentAsObject("ThresholdActive", null);
            ThresholdNormal = reader.ReadElementContentAsObject("ThresholdNormal", null);
            ThresholdEmergency = reader.ReadElementContentAsObject("ThresholdEmergency", null);
            MinOverThresholdDuration = (UInt16)reader.ReadElementContentAsInt("MinOverThresholdDuration");
            MinUnderThresholdDuration = (UInt16)reader.ReadElementContentAsInt("MinUnderThresholdDuration");
            if (reader.IsStartElement("EmergencyProfile", true))
            {
                EmergencyProfile.ID = (UInt16)reader.ReadElementContentAsInt("ID");
                EmergencyProfile.ActivationTime = (GXDateTime)reader.ReadElementContentAsObject("Time", new GXDateTime());
                EmergencyProfile.Duration = (UInt16)reader.ReadElementContentAsInt("Duration");
                reader.ReadEndElement("EmergencyProfile");
            }
            List<UInt16> list = new List<ushort>();
            if (reader.IsStartElement("EmergencyProfileGroupIDs", true))
            {
                while (reader.IsStartElement("Value", false))
                {
                    list.Add((UInt16)reader.ReadElementContentAsInt("Value"));
                }
                reader.ReadEndElement("EmergencyProfileGroupIDs");
            }
            EmergencyProfileGroupIDs = list.ToArray();
            EmergencyProfileActive = reader.ReadElementContentAsInt("Active") != 0;

            if (reader.IsStartElement("ActionOverThreshold", true))
            {
                ActionOverThreshold.LogicalName = reader.ReadElementContentAsString("LN");
                ActionOverThreshold.ScriptSelector = (UInt16)reader.ReadElementContentAsInt("ScriptSelector");
                reader.ReadEndElement("ActionOverThreshold");
            }
            if (reader.IsStartElement("ActionUnderThreshold", true))
            {
                ActionUnderThreshold.LogicalName = reader.ReadElementContentAsString("LN");
                ActionUnderThreshold.ScriptSelector = (UInt16)reader.ReadElementContentAsInt("ScriptSelector");
                reader.ReadEndElement("ActionUnderThreshold");
            }
        }

        void IGXDLMSBase.Save(GXXmlWriter writer)
        {
            if (MonitoredValue != null)
            {
                writer.WriteStartElement("MonitoredValue");
                writer.WriteElementString("ObjectType", (int)MonitoredValue.ObjectType);
                writer.WriteElementString("LN", MonitoredValue.LogicalName);
                writer.WriteEndElement();
            }
            writer.WriteElementObject("ThresholdActive", ThresholdActive);
            writer.WriteElementObject("ThresholdNormal", ThresholdNormal);
            writer.WriteElementObject("ThresholdEmergency", ThresholdEmergency);
            writer.WriteElementString("MinOverThresholdDuration", MinOverThresholdDuration);
            writer.WriteElementString("MinUnderThresholdDuration", MinUnderThresholdDuration);
            if (EmergencyProfile != null)
            {
                writer.WriteStartElement("EmergencyProfile");
                writer.WriteElementString("ID", EmergencyProfile.ID);
                writer.WriteElementObject("Time", EmergencyProfile.ActivationTime);
                writer.WriteElementString("Duration", EmergencyProfile.Duration);
                writer.WriteEndElement();
            }
            if (EmergencyProfileGroupIDs != null)
            {
                writer.WriteStartElement("EmergencyProfileGroupIDs");
                foreach (UInt16 it in EmergencyProfileGroupIDs)
                {
                    writer.WriteElementString("Value", it);
                }
                writer.WriteEndElement();
            }
            writer.WriteElementString("Active", EmergencyProfileActive);

            if (ActionOverThreshold != null)
            {
                writer.WriteStartElement("ActionOverThreshold");
                writer.WriteElementString("LN", ActionOverThreshold.LogicalName);
                writer.WriteElementString("ScriptSelector", ActionOverThreshold.ScriptSelector);
                writer.WriteEndElement();
            }

            if (ActionUnderThreshold != null)
            {
                writer.WriteStartElement("ActionUnderThreshold");
                writer.WriteElementString("LN", ActionUnderThreshold.LogicalName);
                writer.WriteElementString("ScriptSelector", ActionUnderThreshold.ScriptSelector);
                writer.WriteEndElement();
            }
        }

        void IGXDLMSBase.PostLoad(GXXmlReader reader)
        {
            //Upload Monitored Value after load.
            if (MonitoredValue != null)
            {
                GXDLMSObject target = reader.Objects.FindByLN(MonitoredValue.ObjectType, MonitoredValue.LogicalName);
                if (target != MonitoredValue)
                {
                    MonitoredValue = target;
                }
            }
        }
        #endregion
    }
}

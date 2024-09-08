﻿using CrfsdiBim.Core.Common;
using CrfsdiBim.Core.Domain.Projects;
using CrfsdiBim.Core.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace CrfsdiBim.Core
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract partial class BaseEntity
    {
        public BaseEntity()
        {
            Id = SequentialGuidGenerator.Create().ToString();
        }

        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        [Key]
        [MaxLength(200)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the project identifier
        /// </summary>
        [MaxLength(200)]
        public string ProjectId { get; set; } = Singleton<Project>.Instance?.Id;

        /// <summary>
        /// Is transient
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Result</returns>
        private static bool IsTransient(BaseEntity obj)
        {
            return obj != null && Equals(obj.Id, default(string));
        }

        /// <summary>
        /// Get unproxied type
        /// </summary>
        /// <returns></returns>
        private Type GetUnproxiedType()
        {
            return GetType();
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Result</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as BaseEntity);
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other">other entity</param>
        /// <returns>Result</returns>
        public virtual bool Equals(BaseEntity other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (!IsTransient(this) &&
                !IsTransient(other) &&
                Equals(Id, other.Id))
            {
                var otherType = other.GetUnproxiedType();
                var thisType = GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) ||
                        otherType.IsAssignableFrom(thisType);
            }

            return false;
        }

        /// <summary>
        /// Get hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (Equals(Id, default(string)))
                return base.GetHashCode();
            return Id.GetHashCode();
        }

        /// <summary>
        /// Equal
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns>Result</returns>
        public static bool operator ==(BaseEntity x, BaseEntity y)
        {
            return Equals(x, y);
        }

        /// <summary>
        /// Not equal
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns>Result</returns>
        public static bool operator !=(BaseEntity x, BaseEntity y)
        {
            return !(x == y);
        }
    }
}